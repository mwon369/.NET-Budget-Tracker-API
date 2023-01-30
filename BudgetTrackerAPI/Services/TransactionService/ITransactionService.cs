using Microsoft.AspNetCore.Mvc;

namespace BudgetTrackerAPI.Services.TransactionService
{
    public interface ITransactionService
    {
        List<Transaction> GetAllTransactions();
        List<Transaction> GetAllTransactionsFilteredByAmount(decimal minValue, decimal maxValue);
        List<Transaction> GetAllTransactionsFilteredByDate(string startDate, string endDate);
        List<Transaction> GetAllTransactionsThatAreIncoming();
        List<Transaction> GetAllTransactionsThatAreOutgoing();
        List<Transaction> GetAllTransactionsContainingDescription(string description);
        Transaction GetSingleTransactionById(int id);
        List<Transaction> AddTransaction(Transaction transactionToAdd);
        List<Transaction> EditTransaction(Transaction newTransaction);
        List<Transaction> DeleteTransaction(int id);
    }
}
