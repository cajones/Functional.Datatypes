Functional Datatypes
====================

Overview
--------

Datatypes inspired by Haskell implemented in C#

Maybe
-----

The Maybe type encapsulates an optional value. A value of type Maybe a either contains a value of type a (represented as Just a), or it is empty (represented as Nothing). Using Maybe is a good way to deal with errors or exceptional cases without resorting to drastic measures such as error.

The Maybe type is also a monad. It is a simple kind of error monad, where all errors are represented by Nothing. A richer error monad can be built using the Either type.


Either
------

The Either type represents values with two possibilities: a value of type Either a b is either Left a or Right b.

The Either type is sometimes used to represent a value which is either correct or an error; by convention, the Left constructor is used to hold an error value and the Right constructor is used to hold a correct value (mnemonic: "right" also means "correct").

Extensions
----------

Included in this assembly are extensions to assist in working with these datatypes.

*For Maybe*
Bind 
