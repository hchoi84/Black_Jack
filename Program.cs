using System;
using System.Collections.Generic;

namespace _03_DECK_OF_CARDS
{
	class Program
	{
		static void Main(string[] args)
		{
			Boolean isGameOver = false;
			Deck deck = new Deck();
			Player dealer = new Player("dealer");
			Player player = new Player("player");

			dealer.Draw(deck);
			dealer.Draw(deck);
			while (dealer.getHandScore < 15)
				dealer.Draw(deck);
			if (dealer.getHandScore > 21)
			{
				Console.WriteLine("Dealer busts! You win!");
				dealer.ShowCards();
				isGameOver = true;
			}
			Console.WriteLine($"Dealer is done drawing. Dealer has {dealer.getCardCount} cards");
			Console.WriteLine("Dealers visible card:");
			Console.WriteLine(dealer.ShowSecondCard());
			Console.WriteLine("");
			
			player.Draw(deck);
			player.Draw(deck);
			Console.WriteLine("Your cards are:");
			player.ShowCards();

			Console.WriteLine("Hit?");
			string input = Console.ReadLine();
			
			while(!isGameOver && input != "q")
			{
				if (input == "y"){
					Card dealtCard = player.Draw(deck);
					Console.WriteLine($"{dealtCard.getStringVal} of {dealtCard.getSuite}");
					if(player.getHandScore > 21)
					{
						Console.WriteLine("You lose sucker!");
						break;
					}
					else
					{
						Console.WriteLine("Hit?");
						input = Console.ReadLine();
					}
				}
				else if(input == "n")
				{
					Console.WriteLine("");
					Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$");
					Console.WriteLine(dealer.getHandScore > player.getHandScore ? "Dealer WON!" : "Player WON!");
					Console.WriteLine("");

					Console.WriteLine("~~~~~~Dealers cards are:~~~~~~");
					dealer.ShowCards();
					Console.WriteLine(dealer.getHandScore);
					Console.WriteLine("");

					Console.WriteLine("~~~~~~Your cards are:~~~~~~");
					player.ShowCards();
					Console.WriteLine(player.getHandScore);
					break;
				}
			}
		}
	}
}
