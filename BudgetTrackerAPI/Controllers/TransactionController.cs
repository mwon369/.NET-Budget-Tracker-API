using Microsoft.AspNetCore.Mvc;

namespace BudgetTrackerAPI.Controllers
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<Transaction>>> GetAllTransactions()
        {
            var result = await _transactionService.GetAllTransactions();
            return Ok(result);
        }

        [HttpGet("all/by-details")]
        public async Task<ActionResult<List<Transaction>>> GetAllTransactionsFilteredByDetails(TransactionType? transactionType = null,
                                                                                      decimal minValue = 0, 
                                                                                      decimal? maxValue = null,
                                                                                      string startDate = "", 
                                                                                      string endDate = "",
                                                                                      string description = "")
        {
            var result = await _transactionService.GetAllTransactionsFilteredByDetails(transactionType, minValue, maxValue, startDate, endDate, description);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetSingleTransactionById(int id)
        {
            var result = await _transactionService.GetSingleTransactionById(id);
            if (result == null) return BadRequest($"No transaction with an id of {id} exists");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Transaction>>> AddTransaction([FromBody]Transaction transactionToAdd)
        {
            var result = await _transactionService.AddTransaction(transactionToAdd);
            if (result == null) return BadRequest("Transactions cannot have a value below 0");
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<Transaction>>> EditTransaction([FromBody]Transaction newTransaction)
        {
            var result = await _transactionService.EditTransaction(newTransaction);
            if (result == null) return BadRequest($"No transaction with an id of {newTransaction.Id} exists");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Transaction>>> DeleteTransaction(int id)
        {
            var result = await _transactionService.DeleteTransaction(id);
            if (result == null) return BadRequest($"No transaction with an id of {id} exists");
            return Ok(result);
        }
    }
}
