using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz.Models;

namespace Quiz.DAL
{
    public interface IQuizDAL
    {
        List<Question> GetQuestions();
        List<string> GetRightAnswers();
    }
}
