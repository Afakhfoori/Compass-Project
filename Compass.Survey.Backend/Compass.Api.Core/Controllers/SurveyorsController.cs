﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Compass.Domain;
using Compass.Repository.Core;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Compass.Service.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Compass.Api.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SurveyController : ControllerBase
    {

       private readonly ISurveyService _service;

        public SurveyController(ISurveyService service)
        {
            _service = service;
        }

        public object ReferenceHandling { get; private set; }

        [HttpGet("/api/Surveys")]
        public ActionResult<List<Survey>> Get()
        {
            try
            {
                var surveyList = _service.GetAllItems().ToList();
                return Ok(ConvertToProperJSON(surveyList));
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

        }

        [HttpGet("/api/survey/{id}")]
        public ActionResult<Survey> Get(string id)
        {
            try
            {
                var result = _service.GetItemById(id);
                if (result != null)
                {
                    return Ok(ConvertToProperJSON(result));
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

        }
        private string ConvertToProperJSON(Object value)
        {
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var settings = new Newtonsoft.Json.JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented,
                
            };

            return (JsonConvert.SerializeObject(value, settings));

        }
    }
}
