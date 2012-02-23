using System;

namespace Functional.Datatypes
{
    public sealed class Maybe<T>
    {
        private readonly T _value;
        private readonly bool _hasValue;
        public static Maybe<T> Nothing
        {
            get { return new Maybe<T>(); }
        }
        public bool HasValue
        {
            get { return _hasValue; }
        }
        public T Value
        {
            get
            {
                if (!HasValue)
                {
                    throw new InvalidOperationException("Maybe does not have a value");
                }
                return _value;
            }
        }
        public Maybe(T value)
        {
            _hasValue = true;
            _value = value;
        }
        private Maybe()
        {
            _hasValue = false;
            _value = default(T);
        }
    }

    public sealed class Maybe
    {
        public static Maybe<T> Just<T>(T value)
        {
            return new Maybe<T>(value);
        }
    }
}