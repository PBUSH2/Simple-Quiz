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
            List<Question> questionList = dal.GetQuestions();
            Session["questionList"] = questionList;

            return View("Index", questionList);
        }

        
        [HttpPost]
        public ActionResult Index(List<Question> answerList)
        {
           if(answerList == null)
            {
                return RedirectToAction("Index");
            }

            List<string> selectedAnswers = new List<string>();
            for (int i = 0; i < answerList.Count; i++)
            {                           
                selectedAnswers.Add(answerList[i].Answer);
            }
            List<Question> questionList = Session["questionList"] as List<Question>;
            //Session["questionList"] = questionList;
            TempData["answerList"] = selectedAnswers;

            if(answerList.Count < questionList.Count)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("QuizResult");
        }
        public ActionResult QuizResult()
        {    
            List<Question> questionList = new List<Question>();
            questionList = Session["questionList"] as List<Question>;  
            List<string> answerList = TempData["answerList"] as List<string>;
            for (int i = 0; i < questionList.Count; i++)
            {
                questionList[i].Answer = answerList[i];
            }
                 
            List<string> rightAnswers = dal.GetRightAnswers();
            QuizResult quizResult = new QuizResult(questionList, rightAnswers);
          
            return View("QuizResult", quizResult);

        }
    }

}