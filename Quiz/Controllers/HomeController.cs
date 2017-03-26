using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiz.DAL;
using Quiz.Models;

namespace Quiz.Controllers
{
    public class HomeController : Controller
    {
        private readonly IQuizDAL dal;
        public HomeController(IQuizDAL dal)
        {
            this.dal = dal;
        }
        // GET: Home
        public ActionResult Index()
        {
 
            return View("Index", dal.GetQuestions());
        }
        [HttpPost]
        public ActionResult Index(List<Question> questionList)
        {
            Session["questionList"] = questionList;
            return RedirectToAction("QuizResult");
        }
        public ActionResult QuizResult()
        {
            List<Question> questionList = new List<Question>();
            questionList = Session["questionList"] as List<Question>;
            List<string> rightAnswers = dal.GetRightAnswers();
            QuizResult quizResult = new QuizResult(questionList, rightAnswers);
            
            return View("QuizResult", quizResult);

        }
    }

}