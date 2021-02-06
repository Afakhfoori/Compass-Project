using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compass.Domain;
using Compass.Service.Core;

namespace Compass.Api.Unit.Test.Core
{
    public class SurveyServiceFake : ISurveyService
    {
        private readonly List<Survey> _surveyList;
        public SurveyServiceFake()
        {
            _surveyList = new List<Survey>()
            {
                new Survey() { Id = new Guid(),
                   Name = "Survey 1",
                   Questions = new List<Question>() {
                       new Question {
                           Id = new Guid(), Title="Question 1", SubTitle = "Question 1 Subtitle",
                           Options = new List<Option>() {
                           new Option {Id = new Guid(), Text = "Option 1" },
                           new Option {Id = new Guid(), Text = "Option 2" },
                           new Option {Id = new Guid(), Text = "Option 3" },
                           }
                       },
                       new Question {
                           Id = new Guid(), Title="Question 2", SubTitle = "Question 2 Subtitle",
                           Options = new List<Option>() {
                           new Option {Id = new Guid(), Text = "Option 1" },
                           new Option {Id = new Guid(), Text = "Option 2" },
                           new Option {Id = new Guid(), Text = "Option 3" },
                           }
                       }
                   } },
                new Survey() { Id = new Guid(),
                   Name = "Survey 2",
                   Questions = new List<Question>() {
                       new Question {
                           Id = new Guid(), Title="Question 21", SubTitle = "Question 21 Subtitle",
                           Options = new List<Option>() {
                           new Option {Id = new Guid(), Text = "Option 1" },
                           new Option {Id = new Guid(), Text = "Option 1" }
                           }
                        },
                           new Question { Id = new Guid(), Title="Question 22", SubTitle = "Question 22 Subtitle",
                           Options = new List<Option>() {
                           new Option {Id = new Guid(), Text = "Option 1" },
                           new Option {Id = new Guid(), Text = "Option 1" },
                           new Option {Id = new Guid(), Text = "Option 1" }
                           }
                           },

                       }
                   },
            new Survey() { Id = new Guid(),
                   Name = "Survey 3",
                   Questions = new List<Question>() {
                       new Question {
                           Id = new Guid(), Title="Question 31", SubTitle = "Question 31 Subtitle",
                           Options = new List<Option>() {
                           new Option {Id = new Guid(), Text = "Option 1" },
                           new Option {Id = new Guid(), Text = "Option 2" },
                           new Option {Id = new Guid(), Text = "Option 3" },
                           }
                       },
                       new Question {
                           Id = new Guid(), Title="Question 32", SubTitle = "Question 32 Subtitle",
                           Options = new List<Option>() {
                           new Option {Id = new Guid(), Text = "Option 1" },
                           new Option {Id = new Guid(), Text = "Option 2" },
                           new Option {Id = new Guid(), Text = "Option 3" },
                           }
                       }
                   } },};

        }
        public IEnumerable<Survey> GetAllItems()
        {
            return _surveyList;
        }
        public Survey GetItemById(string id)
        {
            return _surveyList.Where(a => a.Id == new Guid(id))
                .FirstOrDefault();
        }
    }
}
