using System;
using System.Collections.Generic;
using System.Text;

namespace FakeCPF {
    class CPF {

        public string Completo;

        public CPF (string cpf)
        {
            Completo = cpf;
        }

        public string Numero()
        {
            string numStr = "";

            foreach (var caracter in Completo)
            {
                if (caracter != '.' && caracter != '-')
                {
                    numStr += caracter;
                }
            }

            return numStr;
        }

        public int DigitoVerificador()
        {
            string tempDigito = "";

            if(Numero().Length == 11)
            {
                tempDigito += Numero()[9];
                tempDigito += Numero()[10];
            }
            else 
            {
                tempDigito += Numero()[9];
            }

            return int.Parse(tempDigito);
        }

        public int CalcDigito1()
        {
            int digVerif;
            int digito;
            int multiplicador = 10;
            int soma = 0;


            //Percorre os 9 primeiros digitos (sem digitos verificadores) e multiplica por 10 decrementando a cada digito
            for(int i=0; i<9; i++)
            {
                digito = (int)(Char.GetNumericValue(Numero()[i])) ;
                soma += digito * multiplicador;

                multiplicador--;
            }

            //Percorre
            if(soma % 11 < 2) {
                digVerif = 0;
            }
            else
            {
                digVerif = 11 - (soma % 11);
            }

            return digVerif;
        }

        public int CalcDigito2()
        {
            int digVerif;
            string numeroCalc = Numero() + CalcDigito1();
            int digito;
            int multiplicador = 11;
            int soma = 0;

            //Percorre os 9 primeiros digitos (sem digitos verificadores) e multiplica por 10 decrementando a cada digito
            for (int i = 0; i < 10; i++)
            {
                digito = (int)(Char.GetNumericValue(numeroCalc[i]));
                soma += digito * multiplicador;

                multiplicador--;
            }

            //Percorre
            if (soma % 11 < 2)
            {
                digVerif = 0;
            }
            else
            {
                digVerif = 11 - (soma % 11);
            }

            return digVerif;
        }

        public bool Valido()
        {
            int verificacao = CalcDigito1() * 10 + CalcDigito2();

            return verificacao == DigitoVerificador();
        }

        /*
        public long Numero;
        public string Nome;
        public string Estado;


        public CPF (long cpf, string estado) {

            Numero = cpf;
            Estado = estado;

        }

        public int[] DigitoCPF() {

            int[] digitoCPF = new int[11];

            for (int i = 0; i < 11; i++) {

                digitoCPF[i] = int.Parse((Numero.ToString()[i]).ToString());

            }

            return digitoCPF;

        }

        public bool SomaDigitosValido () {

            int soma = 0;

            //Passo 1: Soma dos numeros possuem 2 digitos iguais
            for (int i = 0; i < 11; i++) {

                soma = soma + DigitoCPF()[i];

            }

            if (soma.ToString()[0] == soma.ToString()[1]) {
                return true;
            }
            else {
                return false;
            }

        }


        public bool EstadoValido () {

            string nomeEstado = Estado.ToUpper();
            int codigoEstado = 10;

            if (nomeEstado == "RS") {
                codigoEstado = 0;
            }
            else if (nomeEstado == "DF" || nomeEstado == "GO" || nomeEstado == "MT" || nomeEstado == "MS" || nomeEstado == "TO") {
                codigoEstado = 1;
            }
            else if (nomeEstado == "PA" || nomeEstado == "AM" || nomeEstado == "AC" || nomeEstado == "AP" || nomeEstado == "RO" || nomeEstado == "RR") {
                codigoEstado = 2;
            }
            else if (nomeEstado == "CE" || nomeEstado == "MA" || nomeEstado == "PI") {
                codigoEstado = 3;
            }
            else if (nomeEstado == "PE" || nomeEstado == "RN" || nomeEstado == "PB" || nomeEstado == "AL") {
                codigoEstado = 4;
            }
            else if (nomeEstado == "BA" || nomeEstado == "SE") {
                codigoEstado = 5;
            }
            else if (nomeEstado == "MG") {
                codigoEstado = 6;
            }
            else if (nomeEstado == "RJ" || nomeEstado == "ES") {
                codigoEstado = 7;
            }
            else if (nomeEstado == "SP") {
                codigoEstado = 8;
            }
            else if (nomeEstado == "PN" || nomeEstado == "SC") {
                codigoEstado = 9;
            }
            else {
                codigoEstado = 10;
            }
      
            if (DigitoCPF()[8] == codigoEstado) {
                return true;
            }
            else {
                return false;
            }
        }


        public bool DigitoVerificadorValido() {

            int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
           
            bool verificador1 = false;
            bool verificador2 = false;

            int soma = 0;

            //Digito Verificador 1
            for (int i = 0; i < 9; i++) {
                soma = soma + (multiplicador1[i] * DigitoCPF()[i]);
            }

            int resto = soma % 11;

            if (resto < 2) {
                if (DigitoCPF()[9] == 0) {
                    verificador1 = true;
                }
                else {
                    verificador1 = false;
                }
            }
            else {
                if (DigitoCPF()[9] == 11 - resto) {
                    verificador1 = true;
                }
                else {
                    verificador1 = false;
                }
            }

            soma = 0;


            //Digito Verificador 2
            for (int i = 0; i < 10; i++) {
                soma = soma + (multiplicador2[i] * DigitoCPF()[i]);
            }

            resto = soma % 11;

            if (resto < 2) {
                if (DigitoCPF()[10] == 0) {
                    verificador2 = true;
                }
                else {
                    verificador2 = false;
                }
            }
            else {
                if (DigitoCPF()[10] == 11 - resto) {
                    verificador2 = true;
                }
                else {
                    verificador2 = false;
                }
            }


            if (verificador1 == true && verificador2 == true) {
                return true;
            }
            else {
                return false;
            }
            

        }

        public string CPFValido () {

            if (SomaDigitosValido() == true && EstadoValido() == true && DigitoVerificadorValido() == true) {
                return "CPF Válido!!!";
            }
            else if (EstadoValido() == false) {
                return "CPF Inválido: Estado não coincide";
            }
            else if (DigitoVerificadorValido() == false) {
                return "CPF Inválido: Digito verificador incorreto";
            }
            else {
                return "Número de CPF inválido!";
            }

        }

     */
    }
}
