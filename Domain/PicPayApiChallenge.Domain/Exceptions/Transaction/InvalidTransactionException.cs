﻿namespace PicPayApiChallenge.Domain.Exceptions.Transaction
{
    public class InvalidTransactionException : Exception
    {
        public InvalidTransactionException(string message) : base($"{Message}{message}") { }

        public static string Message => "Invalid transaction:";
    }
}
