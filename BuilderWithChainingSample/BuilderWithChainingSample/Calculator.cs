using System.Collections.Generic;

namespace BuilderWithChainingSample
{
    public interface IAction
    {
        IAction Add(decimal value);
        IAction Subtract(decimal value);
        decimal Build();
    }

    public class Calculator : IAction
    {
        private readonly decimal _initialValue;
        private readonly List<KeyValuePair<string, decimal>> _actions;

        private Calculator(decimal value)
        {
            _initialValue = value;
            _actions = new List<KeyValuePair<string, decimal>>();
        }

        public static IAction Start(decimal value)
        {
            return new Calculator(value);
        }

        public IAction Add(decimal value)
        {
            _actions.Add(new KeyValuePair<string, decimal>("add", value));
            return this;
        }

        public IAction Subtract(decimal value)
        {
            _actions.Add(new KeyValuePair<string, decimal>("subtract", value));
            return this;
        }

        public decimal Build()
        {
            var currentValue = _initialValue;
            foreach (var action in _actions)
            {
                switch (action.Key)
                {
                    case "add":
                        currentValue += action.Value;
                        break;
                    case "subtract":
                        currentValue -= action.Value;
                        break;
                }
            }

            return currentValue;
        }
    }
}
