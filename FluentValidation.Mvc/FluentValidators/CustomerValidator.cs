using FluentValidation.Mvc.Models;
using System;

namespace FluentValidation.Mvc.FluentValidators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public string NotEmptyMessage { get; } = "{PropertyName} alanı boş olamaz";

        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(NotEmptyMessage);

            RuleFor(x => x.Email).NotEmpty().WithMessage(NotEmptyMessage)
                                .EmailAddress().WithMessage("Email doğru formatta olmalıdır.");

            RuleFor(x => x.Age).NotEmpty().WithMessage(NotEmptyMessage)
                             .InclusiveBetween(18, 60).WithMessage("Yaş 18 ile 60 arasında olmalıdır.");

            RuleFor(x => x.BirthDay).NotEmpty().WithMessage(NotEmptyMessage).Must(birthDay =>
            {
                return DateTime.Now.AddDays(-18) >= birthDay; //true veya false dönecek
            }).WithMessage("Yaşınız 18'den büyük olmalıdır.");
            //custom validation yazmak için Must kullanıyoruz.
        }
    }
}
