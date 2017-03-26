using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quiz.DAL;
using Quiz.Models;
using System.Data.SqlClient;


namespace Quiz.DAL
{
    public class QuizSqlDAL: IQuizDAL
    {
        private readonly string connectionString;
        public QuizSqlDAL (string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Question>GetQuestions()
        {
            List<Question> questionList = new List<Question>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Select * from questions", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        Question question = new Question()
                        {
                            QuestionString = Convert.ToString(reader["question"]),
                            Choice1 = Convert.ToString(reader["choice_1"]),
                            Choice2 = Convert.ToString(reader["choice_2"]),
                            Choice3 = Convert.ToString(reader["choice_3"]),
                            Choice4 = Convert.ToString(reader["choice_4"]),
                            CorrectAnswer=Convert.ToString(reader["correct_answer"])

                        };
                        questionList.Add(question);
                    }



                }
            }
            catch (Exception)
            {

                throw;
            }
            return questionList;
        }
        public List<string> GetRightAnswers()
        {
            List<string> rightAnswers = new List<string>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Select correct_answer from questions;", conn);

                    SqlDataReader reader= cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        string answer = Convert.ToString(reader["correct_answer"]);
                        rightAnswers.Add(answer);
                    };
                   
                }
            }
            catch (Exception)
            {

                throw;
            }
            return rightAnswers;

        }

    }
}