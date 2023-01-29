using Microsoft.AspNetCore.Mvc;

namespace BudgetTrackerAPI.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        public Transaction AddTransaction([FromBody] Transaction transactionToAdd)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> DeleteTransaction(int id)
        {
            throw new NotImplementedException();
        }

        public Transaction EditTransaction([FromBody] Transaction newTransaction)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetAllTransactions()
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetAllTransactionsContainingDescription(string description)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetAllTransactionsFilteredByAmount(decimal minValue = decimal.MinValue, decimal maxValue = decimal.MaxValue)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetAllTransactionsFilteredByDate(string startDate = "", string endDate = "")
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetAllTransactionsThatAreIncoming()
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetAllTransactionsThatAreOutgoing()
        {
            throw new NotImplementedException();
        }

        public Transaction GetSingleTransactionById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
