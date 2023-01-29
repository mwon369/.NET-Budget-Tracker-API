using Microsoft.AspNetCore.Mvc;

namespace BudgetTrackerAPI.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        private static List<Transaction> _transactionDummyData = new List<Transaction>
        {
            new Transaction
            {
                Id = 1,
                Value = 32.80m,
                Date = DateTime.Now,
                TransactionType = TransactionType.OUTGOING,
                Description = "Dinner"
            },
            new Transaction
            {
                Id = 2,
                Value = 3456.78m,
                Date = new DateTime(2023, 1, 13, 11, 45, 23),
                TransactionType = TransactionType.INCOMING,
                Description = "Got bread"
            },
            new Transaction
            {
                Id = 3,
                Value = 15.50m,
                Date = new DateTime(2023, 1, 18, 13, 32, 48),
                TransactionType = TransactionType.OUTGOING,
                Description = "Lunch"
            },
        };

        public List<Transaction> AddTransaction(Transaction transactionToAdd)
        {
            _transactionDummyData.Add(transactionToAdd);
            return _transactionDummyData;
        }

        public List<Transaction> DeleteTransaction(int id)
        {
            var transactionToDelete = _transactionDummyData.Find(t => t.Id == id);
            _transactionDummyData.Remove(transactionToDelete);
            return _transactionDummyData;
        }

        public List<Transaction> EditTransaction(Transaction newTransaction)
        {
            var transactionToEdit = _transactionDummyData.Find(t => t.Id == newTransaction.Id);

            transactionToEdit.Id = newTransaction.Id;
            transactionToEdit.Value = newTransaction.Value;
            transactionToEdit.Date = newTransaction.Date;
            transactionToEdit.TransactionType = newTransaction.TransactionType;
            transactionToEdit.Description = newTransaction.Description;

            return _transactionDummyData;
        }

        public List<Transaction> GetAllTransactions()
        {
            return _transactionDummyData;
        }

        public List<Transaction> GetAllTransactionsContainingDescription(string description)
        {
            var transactionsWithDescription = _transactionDummyData.Where(t => t.Description.ToLower().Contains(description.ToLower()));
            return transactionsWithDescription.ToList();
        }

        public List<Transaction> GetAllTransactionsFilteredByAmount(decimal minValue, decimal maxValue)
        {
            var transactionsBetweenValues = _transactionDummyData.FindAll(t => t.Value >= minValue && t.Value <= maxValue);
            return transactionsBetweenValues;
        }

        public List<Transaction>? GetAllTransactionsFilteredByDate(string startDate, string endDate)
        {
            if (startDate == "" && endDate == "") return null;

            if (startDate == "")
            {
                var transactionsBeforeEndDate = _transactionDummyData.FindAll(t => t.Date <= DateTime.Parse(endDate));
                return transactionsBeforeEndDate;
            }

            if (endDate == "")
            {
                var transactionsAfterStartDate = _transactionDummyData.FindAll(t => t.Date >= DateTime.Parse(startDate));
                return transactionsAfterStartDate;
            }

            var transactionsBetweenDates = _transactionDummyData.FindAll(t => t.Date >= DateTime.Parse(startDate) && t.Date <= DateTime.Parse(endDate));
            return transactionsBetweenDates;
        }

        public List<Transaction> GetAllTransactionsThatAreIncoming()
        {
            var incomingTransactions = _transactionDummyData.FindAll(t => t.TransactionType == TransactionType.INCOMING);
            return incomingTransactions;
        }

        public List<Transaction> GetAllTransactionsThatAreOutgoing()
        {
            var outgoingTransactions = _transactionDummyData.FindAll(t => t.TransactionType == TransactionType.OUTGOING);
            return outgoingTransactions;
        }

        public Transaction GetSingleTransactionById(int id)
        {
            var transaction = _transactionDummyData.Find(t => t.Id == id);
            return transaction;
        }
    }
}
