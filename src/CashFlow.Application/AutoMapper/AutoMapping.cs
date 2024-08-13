using AutoMapper;
using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.AutoMapper {
    public class AutoMapping : Profile {
        public AutoMapping() {
            RequestToEntity();
            EntityToResponse();
        }

        private void RequestToEntity() {
            CreateMap<RegisterExpenseUseCase, Expense>();
        }

        private void EntityToResponse() {
            CreateMap<Expense, ResponseRegisteredExpenseJson>();
            CreateMap<Expense, ResponseShortExpenseJson>();
            CreateMap<Expense, ResponseExpenseJson>();
        }

    }
}
