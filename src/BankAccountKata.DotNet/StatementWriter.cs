using System;
using System.Collections.Generic;
using static System.DateTime;

namespace Org.Xpdojo.Bank
{
    public class StatementWriter
    {
        private StreamWriter fileWriter;


        public virtual void PrintBalanceOf(Money balance)
        {
            isFileWriterAvalible();
            fileWriter.WriteLine("------------------");
            fileWriter.WriteLine("| date | balance |");
            fileWriter.WriteLine("------------------");
            fileWriter.WriteLine("| " + Now + " | " + balance.ToString() + " |");
            fileWriter.WriteLine("------------------");
        }

        public virtual void PrintFullStatementWith(List<Transaction> transactions)
        {
            isFileWriterAvalible();
            fileWriter.WriteLine("----------------------------------------");
            fileWriter.WriteLine("| date | debit/credit amount | balance |");
            fileWriter.WriteLine("----------------------------------------");
            transactions.ForEach(t => PrintStatementLineTo(fileWriter, t, Money.AnAmountOf(0.0)));
            fileWriter.WriteLine("----------------------------------------");
        }

        private void PrintStatementLineTo(StreamWriter fileWriter, Transaction t, Money balance)
        {
            fileWriter.WriteLine("| " + t.GetDate() + " | " + t.BalanceImpact() + " | " + balance + " |");
        }

        public void SetFileWriter(StreamWriter fileWriter)
        {
            this.fileWriter = fileWriter;
        }


        private void isFileWriterAvalible()
        {
            if (fileWriter == null)
            {
                throw new System.InvalidOperationException("Statement Writer not configured");
            }
        }
    }

}
