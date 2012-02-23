using System;

namespace Functional.Datatypes
{
    public sealed class Either<TL, TR>
    {
        private readonly Maybe<TL> _leftValue = Maybe<TL>.Nothing;
        private readonly Maybe<TR> _rightValue = Maybe<TR>.Nothing;
        private readonly bool _isRight;
        private Either(TL value)
        {
            _leftValue = Maybe.Just(value);
        }
        private Either(TR value)
        {
            _isRight = true;
            _rightValue = Maybe.Just(value);
        }
        public static Either<TL, TR> Left(TL value)
        {
            return new Either<TL, TR>(value);
        }
        public static Either<TL, TR> Right(TR value)
        {
            return new Either<TL, TR>(value);
        }
        public bool IsRight
        {
            get { return _isRight; }
        }
        public Maybe<TL> LeftValue
        {
            get
            {
                return _leftValue;
            }
        }
        public Maybe<TR> RightValue
        {
            get
            {
                return _rightValue;
            }
        }
        public T Analyse<T>(Func<TL, T> left, Func<TR, T> right)
        {
            return _isRight
                       ? right(_rightValue.Value)
                       : left(_leftValue.Value);
        }
    }
}
