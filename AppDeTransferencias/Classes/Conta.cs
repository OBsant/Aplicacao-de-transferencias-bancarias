using System;

namespace AppDeTransferencias
{
    public class Conta
    {
        
		private TipoConta TipoConta { get; set; }
		private double Saldo { get; set; }
		private double Credito { get; set; }
		private double Cofre { get; set; }
		private string Nome { get; set; }

		public Conta(TipoConta tipoConta, double saldo, double credito, double cofre,string nome)
		{

			this.TipoConta = tipoConta;
			this.Saldo = saldo;
			this.Credito = credito;
			this.Cofre = cofre;
			this.Nome = nome;

		}

		public bool Sacar(double valorSaque)
		{

            if (this.Saldo - valorSaque < (this.Credito *-1)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            this.Saldo -= valorSaque;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

            return true;

		}

		public void Depositar(double valorDeposito)
		{

			this.Saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

		}

		public void Transferir(double valorTransferencia, Conta contaDestino)
		{

			if (this.Sacar(valorTransferencia)){

                contaDestino.Depositar(valorTransferencia);

            }
            
		}

		public bool GuardarNoCofre(double valorGuardar)
		{

            if (this.Saldo - valorGuardar < (this.Credito *-1)){

                Console.WriteLine("Saldo insuficiente!");
                return false;

            }

			this.Cofre += valorGuardar;
            this.Saldo -= valorGuardar;

			Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

            return true;
        
		}

        public override string ToString()
		{
            string retorno = "";
            
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito + " | ";
			retorno += "Valor Guardado " + this.Cofre;

			return retorno;
		}
    }
}