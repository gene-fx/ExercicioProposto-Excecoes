using System.Globalization;
using ExercicioProposto_Excecoes.Entities.Exceptions;


namespace ExercicioProposto_Excecoes.Entities
{
    class Account
    {
        public string Holder { get; set; }
        public int Number { get; set; }
        public double Balance { get; set; }
        public double WithdrawLimit { get; set; }

        public Account(string holder, int number, double balance, double withdrawLimit)
        {
            Holder = holder;
            Number = number;
            Balance = balance;
            WithdrawLimit = withdrawLimit;
        }

        public void Withdraw(double withDraw)
        {
            if(withDraw > Balance)
            {
                throw new DomainException("Insufficient funds.");
            }
            else if(withDraw >= WithdrawLimit)
            {
                throw new DomainException("Withdraw limit reached.");
            }
            else
                Balance -= withDraw;
        }
    }
}
