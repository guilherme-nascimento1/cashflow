using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses {
    public interface IExpensesWriteOnlyRepository {
        Task AddExpenses(Expense expense);
        /// <summary>
        /// this function returns true if the deletion was successfull otherwise returns FALSE.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Delete(long id);
    }
}
