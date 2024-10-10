namespace ConsoleApp.Entities
{
    public class ValidadorCPF
    {
        public static bool Validar(string cpf)
        {
            cpf = cpf.Trim().Replace(".", "").Replace("-", "").Replace(" ", ""); // Remover pontos, espaços e vírgulas

            if (cpf.Length != 11)
                return false;

            if (new string(cpf[0], cpf.Length) == cpf)
                return false; // Se todos os números forem iguais dá como inválido

            int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 }; // Cálculo do primeiro dígito do CPF
            int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 }; // Cálculo do segundo dígito do CPF
            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i]; // Faz as multiplicações com base no cálculo validador de CPF para o primeiro dígito

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();

            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i]; // Faz as multiplicações com base no cálculo validador de CPF para o segundo dígito

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            // Confere os dígitos
            return cpf.EndsWith(digito);
        }
    }
}
