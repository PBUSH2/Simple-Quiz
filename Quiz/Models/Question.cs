using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quiz.Models
{
    public class Question
    {
        public string QuestionString { get; set; }
        public string Choice1 { get; set; }
        public string Choice2 { get; set; }
        public string Choice3 { get; set; }
        public string Choice4 { get; set;}
        public string Answer { get; set; }
        public string CorrectAnswer { get; set; }

    }
}