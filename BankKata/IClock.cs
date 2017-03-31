using System;

namespace BankKata
{
    public interface IClock
    {
        DateTime Today { get; }
    }
}