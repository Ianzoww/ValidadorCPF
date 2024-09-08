using System;
class CPF
{
    static void Main()
    {
        while (true)
        {
            //Exibir mensagem na tela.
            Console.Write("Digite um CPF: ");

            string CPF = Console.ReadLine();
            //Chamar a funcao que verifica o CPF.
            Console.WriteLine(VerificaCPF(CPF) ? "CPF válido!\n" : "CPF invalido!\n");
        }
    }
    //Funcao para verificar se o CPF é valido.
    public static bool VerificaCPF(string CPF)
    {
        //Vetor para 1º multiplicacao
        int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        //Vetor para 2º multiplicacao
        int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        string CPF1, CPF2;
        int soma, resultado;

        //Remover os espacos em brancos do CPF , se tiver
        CPF = CPF.Trim();

        //Remover os sinais de ponto e traco por nada no lugar , ficando somente a sequencia
        CPF = CPF.Replace(".", "").Replace("-", "");

        //Verificar se o tamanho do CPF é diferente de 11 ou se possui digitos repetidos
        if (CPF.Length != 11 || CPF == "000.000.000-00" || CPF == "00000000000" || CPF == "111.111.111-11" || CPF == "11111111111" || CPF == "222.222.222-22" || CPF == "333.333.333-33" || CPF == "33333333333" || CPF == "444.444.444-44" || CPF == "44444444444" || CPF == "555.555.555-55" || CPF == "55555555555" || CPF == "666.666.666-66" || CPF == "66666666666" || CPF == "777.777.777-77" || CPF == "77777777777" || CPF == "888.888.888-88" || CPF == "88888888888" || CPF == "999.999.999-99" || CPF == "99999999999")
        {
            return false;
        }
        //Atribuir a CPF1 a contagem de 0 a 10 dos digitos do CPF
        CPF1 = CPF.Substring(0, 10);

        //Valor inicial da soma.
        soma = 0;
        for (int i = 0; i < 9; i++)
        {
            //Multiplicar os digitos do CPF pelos Pesos.
            soma += int.Parse(CPF1[i].ToString()) * multiplicador1[i];
        }
        //Extrair o resto da divisao da soma por 11.
        resultado = soma % 11;
        //Se o resto da divisao for menor do que 2 , o primeiro digito verificador se torna 0.
        if (resultado < 2)
        {
            //Valor do primeiro digito verificador se o resto for menor que 2.
            resultado = 0;
        }
        //Se o resto for maior que 2 , subtrair de 11 o resto.
        else
        {
            resultado = 11 - resultado;
        }

        //Fim do calculo do primeiro digito verificador do CPF
        //Inicio do calculo do segundo digito verificador do CPF

        //Recebe o primeiro digito verificador
        CPF2 = resultado.ToString();
        CPF1 = CPF1 + CPF2;

        //Valor inicial da soma
        soma = 0;
        for (int j = 0; j < 10; j++)
        {
            //Multiplicar os digitos do CPF pelos Pesos.
            soma += int.Parse(CPF1[j].ToString()) * multiplicador2[j];
        }
        //Extrair o resto da divisao da soma por 11.
        resultado = soma % 11;

        //Se o resto da divisao for menor do que 2 , o primeiro digito verificador se torna 0.
        if (resultado < 2)
        {
            //Valor do primeiro digito verificador se o resto for menor que 2.
            resultado = 0;
        }

        //Se o resto for maior que 2 , subtrair de 11 o resto.
        else
        {
            resultado = 11 - resultado;
        }

        //Recebe o segundo digito verificador
        CPF2 = CPF2 + resultado.ToString();
        //Verificar se o CPF termina com os digitos verificadores calculados e retorna True ou False
        return CPF.EndsWith(CPF2);
    }
}