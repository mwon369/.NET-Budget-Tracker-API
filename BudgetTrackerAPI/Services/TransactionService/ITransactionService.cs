using Microsoft.AspNetCore.Mvc;

namespace BudgetTrackerAPI.Services.TransactionService
{
    public interface ITransactionService
    {
        List<Transaction> GetAllTransactions();
        List<Transaction> GetAllTransactionsFilteredByAmount(decimal minValue = decimal.MinValue, decimal maxValue = decimal.MaxValue);
        List<Transaction> GetAllTransactionsFilteredByDate(string startDate = "", string endDate = "");
        List<Transaction> GetAllTransactionsThatAreIncoming();
        List<Transaction> GetAllTransactionsThatAreOutgoing();
        List<Transaction> GetAllTransactionsContainingDescription(string description);
        Transaction GetSingleTransactionById(int id);
        Transaction AddTransaction([FromBody] Transaction transactionToAdd);
        Transaction EditTransaction([FromBody] Transaction newTransaction);
        List<Transaction> DeleteTransaction(int id);

    }
}
