namespace _932101.Nasution.Rafly.lab12.Models
{
    public class Model
    {
        public int num1 { get; set; }
        public int num2 { get; set; }
        public string? operation { get; set; }

        public string Evaluate()
        {
            return operation switch
            {
                "+" => $"{num1} + {num2} = {num1 + num2}",
                "-" => $"{num1} - {num2} = {num1 - num2}",
                "*" => $"{num1} * {num2} = {num1 * num2}",
                "/" when num2 != 0 => $"{num1} / {num2} = {Math.Round((float)num1 / num2),2}",
                "/" when num2 == 0 => "Divide by zero!",
                _ => "Wrong operation"
            };
        }
    }
}