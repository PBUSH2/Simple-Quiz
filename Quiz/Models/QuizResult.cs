using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quiz.Models;

namespace Quiz.Models
{
    public class QuizResult
    {
        public List<Question> quiz;
        public List<String> rightAnswers;
        public QuizResult(List<Question> quiz, List<string> rightAnswers)
        {
            this.rightAnswers = rightAnswers;
            this.quiz = quiz;
        }


        public int GetNumberRight()
        {
            int numberRight = 0;
            for (int i = 0; i < quiz.Count; i++)
            {
                if (quiz[i].Answer == rightAnswers[i])
                {
                    numberRight++;
                }

            }
            return numberRight;
        }


    }
}