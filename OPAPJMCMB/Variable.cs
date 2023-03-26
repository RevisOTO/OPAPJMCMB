using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPAPJMCMB
{
    class Variable
    {
		private string? strIdentificador;

		public string? Identificador
		{
			get { return strIdentificador; }
			set { strIdentificador = value; }
		}

		private string? strVariiable;

		public string? Var
		{
			get { return strVariiable; }
			set { strVariiable = value; }
		}

		private int intFila;

		public int Fila
		{
			get { return intFila; }
			set { intFila = value; }
		}

		private string? strTipo;

		public string? Tipo
		{
			get { return strTipo; }
			set { strTipo = value; }
		}

	}
}
