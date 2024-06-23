using CadetTest.Entities;
using CadetTest.Models;
using CadetTest.Services;
using CadetTest.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadetTest.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsentsController : ControllerBase
    {
        private ILogger<ConsentsController> _logger;
        private AppSettings _appSettings;
        private IDataService _dataService;
        private readonly JsonSerializerSettings _jsonSettings;
        private readonly IConsentService _consentService;

        public ConsentsController(ILogger<ConsentsController> logger, IOptions<AppSettings> appSettings, IDataService dataService, IConsentService consentService)
        {
            _logger = logger;
            _appSettings = appSettings.Value;
            _dataService = dataService;
            _jsonSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            _consentService = consentService;
        }
        [HttpPost("GetConsents")]
        public IActionResult GetConsents([FromBody] ConsentRequest request)
        {
            var consents = _dataService.GetRangeById(request.StartId, request.Count);
            return Ok(consents);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetConsentById(int id)
        {
            var consent = await _consentService.GetConsentByIdAsync(id);
            if (consent == null)
            {
                return NotFound();
            }
            return Ok(consent);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllConsents()
        {
            var consents = await _consentService.GetAllConsentsAsync();
            return Ok(consents);
        }

        [HttpPost]
        public async Task<IActionResult> AddConsent([FromBody] Consent consent)
        {
            if (consent == null)
            {
                return BadRequest();
            }
            await _consentService.AddConsentAsync(consent);
            return CreatedAtAction(nameof(GetConsentById), new { id = consent.Id }, consent);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateConsent([FromBody] Consent consent)
        {
           
            await _consentService.UpdateConsentAsync(consent);
            return Ok(consent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveConsent(int id)
        {
            var consent = await _consentService.GetConsentByIdAsync(id);
            if (consent == null)
            {
                return NotFound();
            }
            await _consentService.RemoveConsentAsync(id);
            return NoContent();
        }
    }
}
