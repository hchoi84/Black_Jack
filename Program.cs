using System;
using System.Collections.Generic;

namespace _03_DECK_OF_CARDS
{
	class Program
	{
		static void Main(string[] args)
		{

			System.Console.WriteLine("Welcome to Black Jack!");
			var again = "y";
			Boolean isGameOver = false;
			Deck deck = new Deck();
			deck.Shuffle();
			Player dealer = new Player("dealer");
			Player player = new Player("player");

			while(again == "y" && !isGameOver)
			{
				System.Console.WriteLine("New Round has started...");

				var isRoundOver = false;
				Boolean isWinner;

				var bet = 0;

				dealer.Draw(deck);
				player.Draw(deck);
				dealer.Draw(deck);
				player.Draw(deck);

				Console.WriteLine("Dealers visible card:");
				dealer.ShowSecondCard();
				Console.WriteLine("");
				Console.WriteLine("Your cards are:");
				player.ShowCards();
				Console.WriteLine("");

				//Ask for bet.
				while(true)
				{
					Console.WriteLine($"Bet between 1 and {player.coins}");
					string tryint = Console.ReadLine();
					if (Int32.TryParse(tryint, out int intBet))
					{
						bet = intBet;
					}
					else
					{
						bet = 0;
					}
					if(bet >= 1 && bet <= player.coins)
					{
						player.PlaceBet(bet);
						Console.WriteLine($"Player has {player.coins} coins remaining.");
						break;
					}
				}

				while(!isRoundOver)
				{
					// Ask if player hits or stays.
					Console.WriteLine("Hit? y/n");
					string input = Console.ReadLine();
					// If player hits, draw and show new card.
					if (input == "y"){
						Card dealtCard = player.Draw(deck);
						string cardVal = "" + dealtCard.getStringVal[0];
						if (cardVal == "1")
						{
							cardVal = "10";
						}
						player.ShowCardA(cardVal, dealtCard.getSuit);
					}
					// If player stays, round ends and dealer may draw.
					else if(input == "n")
					{
						isRoundOver = true;
						// Dealer draws card if necessary.
						while (dealer.getHandScore < 15)
						{
							Console.WriteLine($"Dealer draws card #{dealer.getCardCount}.");
							dealer.Draw(deck);
							if(dealer.getHandScore > 21)
							{
								// Change Ace value to 1.
								foreach (var card in dealer.getCards)
								{
									if(card.changeVal == 11)
									{
										card.changeVal = 1;
										break;
									}
								}
							}
						}
					}
					// Prevent player from drawing if bust.
					if(player.getHandScore > 21)
					{
						// Change Ace value to 1.
						foreach (var card in player.getCards)
						{
							if(card.changeVal == 11)
							{
								card.changeVal = 1;
								break;
							}
						}
						// If still over 21...
						if(player.getHandScore > 21)
						{
							isRoundOver = true;
						}
					}
				}

				//Round is over, display all cards.
				Console.WriteLine("");
				Console.WriteLine("~~~~~~Dealers cards are:~~~~~~");
				dealer.ShowCards();
				Console.WriteLine($"Dealer total is {dealer.getHandScore}.");
				Console.WriteLine("");
				Console.WriteLine("~~~~~~Your cards are:~~~~~~");
				player.ShowCards();
				Console.WriteLine($"Player total is {player.getHandScore}.");
				
				// Check win condition.
				if (dealer.getHandScore > 21)
				{
					isWinner = true;
					player.PrintWin();
				}
				else if (player.getHandScore > 21)
				{
					isWinner = false;
					player.PrintLose();
				}
				else if (dealer.getHandScore > player.getHandScore)
				{
					isWinner = false;
					player.PrintLose();
				}
				else if (dealer.getHandScore == player.getHandScore)
				{
					isWinner = false;
					player.coins += bet;
					player.PrintPush();
				}
				else
				{
					isWinner = true;
					player.PrintWin();
				}
				// Clear cards and reset deck.
				player.DiscardAll();
				dealer.DiscardAll();
				deck.Reset();
				deck.Shuffle();

				//Update Coins
				player.BetResult(isWinner);

				// Display winnings.
				Console.WriteLine($"Player has {player.coins} coins.");

				// Check if player can play again.
				if(player.coins <= 0)
				{
					isGameOver = true;
					break;
				}
				// Play again or end game.
				Console.WriteLine("Play again? y/n");
				again = Console.ReadLine();
			}
			
			if (player.coins > 0 )
			{
				Console.WriteLine($"Player ended the game with {player.coins} coins.");
			}
			else
			{
				Console.WriteLine("You are broke.  Goodbye!");
			}
		}
	}
}
