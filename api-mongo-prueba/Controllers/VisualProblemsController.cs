using api_mongo_prueba.Data;
using api_mongo_prueba.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace api_mongo_prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisualProblemsController : ControllerBase
    {
        // create mongo collection of VisualProblems type, to manage the documents in DB.
        private readonly IMongoCollection<VisualProblems>? _visualProblems;
        public VisualProblemsController(MongoDbService mongoDbService)
        {
            // get the collection in DB.
            _visualProblems = mongoDbService.Database?.GetCollection<VisualProblems>("visual_problems");
        }

        [HttpGet]
        public async Task<IEnumerable<VisualProblems>> Get()
        {
            // find the documents on DB. and return a list of elements.
            return await _visualProblems.Find(FilterDefinition<VisualProblems>.Empty).ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<VisualProblems?>> GetById(string id)
        {
            // create filter to find elements by Id.
            var filter = Builders<VisualProblems>.Filter.Eq(x => x.Id, id);
            var visualProblem = await _visualProblems.Find(filter).FirstOrDefaultAsync();

            // return Ok response if exist element, if not retrn not found.
            return visualProblem is not null ? Ok(visualProblem) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Create(VisualProblems visualProblem)
        {
            await _visualProblems.InsertOneAsync(visualProblem);
            // return the element created
            return CreatedAtAction(nameof(GetById), new {id = visualProblem.Id}, visualProblem);
        }

        [HttpPut]
        public async Task<ActionResult> Update(VisualProblems visualProblem)
        {
            // create filter to find elements by Id.
            var filter = Builders<VisualProblems>.Filter.Eq(x => x.Id, visualProblem.Id);
            // update the elements
            //var update = Builders<VisualProblems>.Update
            //    .Set(x => x.Name, visualProblem.Name)
            //    .Set(x => x.Description, visualProblem.Description)
            //    .Set(x => x.Symptoms, visualProblem.Symptoms)
            //    .Set(x => x.Causes, visualProblem.Causes)
            //    .Set(x => x.Treatments, visualProblem.Causes)
            //    .Set(x => x.ToConsider, visualProblem.ToConsider);
            //await _visualProblems.UpdateOneAsync(filter, update);

            await _visualProblems.ReplaceOneAsync(filter, visualProblem);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            // create filter to find elements by Id.
            var filter = Builders<VisualProblems>.Filter.Eq(x => x.Id, id);
            await _visualProblems.DeleteOneAsync(filter);
            return Ok();
        }
    }
}
