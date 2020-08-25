# PotterKata
AO Potter Kata

# Kata Spec
To try and encourage more sales of the 5 different Harry Potter books they sell, a bookshop has decided to offer
discounts of multiple-book purchases.

One copy of any of the five books costs 8 EUR.

If, however, you buy two different books, you get a 5% discount on those two books.

If you buy 3 different books, you get a 10% discount.

If you buy 4 different books, you get a 20% discount.

If you go the whole hog, and buy all 5, you get a huge 25% discount.

Note that if you buy, say, four books, of which 3 are different titles, you get a 10% discount on the 3 that form part of a set, but the fourth book still costs 8 EUR.

Your mission is to write a piece of code to calculate the price of any conceivable shopping basket (containing only Harry Potter books), giving as big a discount as possible.

For example, how much does this basket of books cost?

2 copies of the first book
2 copies of the second book
2 copies of the third book
1 copy of the fourth book
1 copy of the fifth book

Answer: 51.20 EUR

# Query
I feel I need a little more information on the final part of the spec may be giving the incorrect figure to expect on the basket total.

I believe there are two ways of this working.
1: We calculate a discount based on a single set, then charge the remaining 3 books at full price
5 distinct books charged at 8EUR with a discount of 25% = 30EUR
Remaining 3 books charged at 8EUR with no discount = 24EUR
Total Payable = 54EUR

2: We calculate discounts on a set by set basis. That is, we have one full set, and one partial set of 3.
5 distinct books charged at 8EUR with a discount of 25% = 30EUR
3 additional distinct books (separate to the previous 5) charged at 8EUR with a discount of 10% = 21.60EUR
Total Payable = 51.60EUR

Due to the above, with not being able to get further information (and for the purpose of this exersise) I have gone with option 2.

# My Approach
I took a TDD approach to this kata. I wrote out all the tests with expected outcomes first, then coded the functionality to fit the tests.

I used a .net core class library for the business logic, and a separate one for the tests.

I used xunit for the tests.