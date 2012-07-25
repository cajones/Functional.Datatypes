using System;

namespace Functional.Datatypes
{
    public sealed class Maybe<T> : IEquatable<Maybe<T>>
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
        internal Maybe(T value)
        {
            _hasValue = true;
            _value = value;
        }
        internal Maybe()
        {
            _hasValue = false;
            _value = default(T);
        }

        #region Equality
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Maybe<T>)) return false;
            return Equals((Maybe<T>)obj);
        }

        public bool Equals(Maybe<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other._value, _value);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static bool operator ==(Maybe<T> left, Maybe<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Maybe<T> left, Maybe<T> right)
        {
            return !Equals(left, right);
        } 
        #endregion
    }

    public sealed class Maybe
    {
        public static Maybe<T> Just<T>(T value)
        {
            return Equals(value, null) 
                        ? Maybe<T>.Nothing 
                        : new Maybe<T>(value);
        }
    }
}