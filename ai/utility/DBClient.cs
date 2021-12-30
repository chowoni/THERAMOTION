using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace ai.utility
{
    public class DBClient
    {
        private string? mPhone = null;
        private string mTestDate;
        private string mTestLocation;
        private string mTestID;

        /// <summary>
        /// 유저로그 등록, InputUserInfo(핸드폰번호, 테스트시작시간, 테스트장소)
        /// </summary>
        /// <param name="Phone"></param>
        /// <param name="TestDate"></param>
        /// <param name="TestLocation"></param>
        public void InputUserInfo(string Phone, DateTime TestDate, string TestLocation)
        {
            mPhone = Phone;
            mTestDate = TestDate.ToString("yyyy-MM-dd HH:mm:ss");
            mTestLocation = TestLocation;

            if (string.IsNullOrEmpty(mPhone) || string.IsNullOrEmpty(this.mTestDate) || string.IsNullOrEmpty(this.mTestLocation))
                return;

            TCPHelper.Connect();
            if (TCPHelper.IsConnected)
            {
                mTestID = TCPHelper.CreateUserTestID(mPhone, mTestDate, mTestLocation);
                TCPHelper.DisConnect();
            }
            
        }

        /// <summary>
        /// 질문A 답변, 점수 등록, InputQuestionA(int[] 답변들, double 점수)
        /// </summary>
        /// <param name="Answers"></param>
        /// <param name="Score"></param>
        public void InputQuestionA(int[] Answers, double Score)
        {
            if (Answers == null)
                return;

            List<string> listAnswer = new List<string>();
            foreach (var item in Answers)
            {
                listAnswer.Add(item.ToString());
            }

            TCPHelper.Connect();
            if (TCPHelper.IsConnected)
            {
                var result = TCPHelper.InputQuestionData(TCPHelper.QuestionType.QuestionA, mTestID, listAnswer, Score.ToString());
                TCPHelper.DisConnect();
            }
        }
        public void InputQuestionB(int[] Answers, double Score)
        {
            if (Answers == null)
                return;

            List<string> listAnswer = new List<string>();

            foreach (var item in Answers)
            {
                listAnswer.Add(item.ToString());
            }

            TCPHelper.Connect();
            if (TCPHelper.IsConnected)
            {
                var result = TCPHelper.InputQuestionData(TCPHelper.QuestionType.QuestionB, mTestID, listAnswer, Score.ToString());
                TCPHelper.DisConnect();
            }

           
        }
        public void InputQuestionC(int[] Answers, double Score)
        {
            if (Answers == null)
                return;

            List<string> listAnswer = new List<string>();

            foreach (var item in Answers)
            {
                listAnswer.Add(item.ToString());
            }

            TCPHelper.Connect();
            if (TCPHelper.IsConnected)
            {
                var result = TCPHelper.InputQuestionData(TCPHelper.QuestionType.QuestionC, mTestID, listAnswer, Score.ToString());
                TCPHelper.DisConnect();
            }
        }

        public void InputPoseA(List<string> listPosition, double Score)
        {
            if (listPosition == null)
                return;

            TCPHelper.Connect();
            if (TCPHelper.IsConnected)
            {
                var result = TCPHelper.InputPoseData(TCPHelper.PoseType.PoseA, mTestID, listPosition, Score.ToString());
                TCPHelper.DisConnect();
            }
        }
        public void InputPoseB(List<string> listPosition, double Score)
        {
            if (listPosition == null)
                return;

            TCPHelper.Connect();
            if (TCPHelper.IsConnected)
            {
                var result = TCPHelper.InputPoseData(TCPHelper.PoseType.PoseB, mTestID, listPosition, Score.ToString());
                TCPHelper.DisConnect();
            }
        }

    }

    internal static class TCPHelper
    {
        const string ServerIP = "minehealth.awesomeserver.kr";
        const int ServerPort = 9090;

        private static TcpClient client = null;
        private static NetworkStream ns = null;
        private static StreamReader sr = null;
        private static StreamWriter sw = null;

        internal enum QuestionType
        {
            QuestionA = 0,
            QuestionB = 1,
            QuestionC = 2
        }

        internal enum PoseType
        {
            PoseA = 0,
            PoseB = 1
        }

        private static bool _IsConnected = false;
        /// <summary>
        /// 연결여부를 체크하는 플래그, true: 연결중
        /// </summary>
        internal static bool IsConnected
        {
            set
            {
                _IsConnected = value;
            }
            get
            {
                return _IsConnected;
            }
        }

        /// <summary>
        /// Server에 연결, Connect(서버IP, 포트);
        /// </summary>
        /// <param name="serverIP"></param>
        /// <param name="port"></param>
        /// <returns>
        /// 성공: "Server Connnect Success!" <para/>
        /// 실패: 오류메세지 출력
        /// </returns>
        internal static string Connect(string serverIP = ServerIP, int port = ServerPort)
        {
            if (serverIP == "")
                serverIP = ServerIP;
            if (port == 0)
                port = ServerPort;

            try
            {
                client = new TcpClient(serverIP, port);
                ns = client.GetStream();
                sr = new StreamReader(ns);
                sw = new StreamWriter(ns);

                IsConnected = true;

                var result = sr.ReadLine();
                Task.Delay(100);
                return result;
            }
            catch (SocketException ex)
            {
                IsConnected = false;
                return ex.Message;
            }
        }

        /// <summary>
        /// 서버 연결 해제, DisConnect()
        /// </summary>
        internal static void DisConnect()
        {
            if (IsConnected)
            {
                sw.WriteLine("exit");
                sw.Flush();
                Task.Delay(100);

                sr.Close();
                sw.Close();
                ns.Close();
                client.Close();
                _IsConnected = false;
            }
        }


        internal static string CreateUserTestID(string Phone, string TestDate, string TestLocation)
        {
            string result = null;

            var connect = Connect();
            
            if (IsConnected)
            {
                sw.WriteLine("USERLOGINPUT " + Phone + "," + TestDate + "," + TestLocation);
                sw.Flush();

                Task.Delay(300);    // 데이터를 받아오는 시간

                result = sr.ReadLine();

                sw.Flush();
                DisConnect();
            }

            return result;
        }

        internal static string InputQuestionData(QuestionType Category, string TestId, List<string> Answer, string Score)
        {
            string result = null;

            string orderName = "";
            switch(Category)
            {
                case QuestionType.QuestionA:
                    orderName = "QAINSERT ";
                    break;
                case QuestionType.QuestionB:
                    orderName = "QBINSERT ";
                    break;
                case QuestionType.QuestionC:
                    orderName = "QCINSERT ";
                    break;
            }

            string answer = "";

            foreach (var item in Answer)
            {
                answer += item + ",";
            }

            sw.WriteLine(orderName + TestId + ","  + answer + Score);
            sw.Flush();

            result = sr.ReadLine();

            sw.Flush();
            DisConnect();

            return result;
        }

        internal static string InputPoseData(PoseType Category, string TestId, List<string> Position, string Score)
        {
            string result = null;

            string orderName = "";

            switch (Category)
            {
                case PoseType.PoseA:
                    orderName = "PAINSERT ";
                    break;
                case PoseType.PoseB:
                    orderName = "PBINSERT ";
                    break;
            }

            string pose  = "";

            foreach (var item in Position)
            {
                pose += item + ",";
            }

            sw.WriteLine(orderName + TestId + "," + pose + Score);
            sw.Flush();

            result = sr.ReadLine();

            sw.Flush();
            DisConnect();

            return result;
        }
    }
}
