namespace Player
{
    public class StatePredicate : IPredicate
    {
        private bool _state = false;

        public void setState(bool newState)
        {
            _state = newState;
        }

        public bool Evaluate()
        {
            if (_state)
            {
                _state = false;
                return true;
            }
            return false;
        }
    }
}