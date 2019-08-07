using System;
using System.Collections.Generic;

class Player
{
  private string name;
  private List<Card> hand = new List<Card>();
  private int handScore;

  public int getHandScore{ get{return handScore;} }
  public int getCardCount{ get{return hand.Count;} }

  public Player(string name){
    this.name = name;
  }

  public Card Draw(Deck deck){
    Card dealtCard = deck.Deal();
    hand.Add(dealtCard);
    handScore += dealtCard.getVal;
    return dealtCard;
  }

  public Card Discard(int index){
    if (hand[index] == null){
      return null;
    }
    Card discardedCard = hand[index];
    hand.RemoveAt(index);
    return discardedCard;
  }

  public void ShowCards()
  {
    foreach (Card c in hand)
    {
      string cardVal = "" + c.getStringVal[0];
      if (cardVal == "1")
      {
        cardVal = "10";
      }
      ShowCardA(cardVal, c.getSuit);
    }
  }
  public void ShowSecondCard()
  {
      Card SecondCard = hand[0];
      string cardVal = "" + SecondCard.getStringVal[0];
      if (cardVal == "1")
      {
        cardVal = "10";
      }
      ShowCardA(cardVal, SecondCard.getSuit);
  }

  public void ShowCardA(string val, string suit) {
      string val2 = " " + val;
      if (val.Length == 1)
      {
          val2 = "  " + val;
          val = val + " ";
      }
      if (suit == "Spades")
      {
          System.Console.WriteLine( " _______");
          System.Console.WriteLine($"|{val}     |");
          System.Console.WriteLine($"|   .   |");
          System.Console.WriteLine( "|  /.\\  |");
          System.Console.WriteLine( "| (_._) |");
          System.Console.WriteLine( "|   |   |");
          System.Console.WriteLine($"|    {val2}|");
          System.Console.WriteLine($"|_______|");
      }
      if (suit == "Diamonds")
      {
          System.Console.WriteLine( " _______");
          System.Console.WriteLine( $"|{val}     |");
          System.Console.WriteLine($"|   ^   |");
          System.Console.WriteLine( "|  / \\  |");
          System.Console.WriteLine( "|  \\ /  |");
          System.Console.WriteLine( $"|   .{val2}|");
          System.Console.WriteLine("|_______|");
      }
      if (suit == "Clubs")
      {
          System.Console.WriteLine( " _______");
          System.Console.WriteLine($"|{val}     |");
          System.Console.WriteLine("|   _   |");
          System.Console.WriteLine( "|  ( )  |");
          System.Console.WriteLine( "| (_'_) |");
          System.Console.WriteLine( "|   |   |");
          System.Console.WriteLine($"|    {val2}|");
          System.Console.WriteLine($"|_______|");
      }
      if (suit == "Hearts")
      {
          System.Console.WriteLine(" _______");
          System.Console.WriteLine($"|{val}     |");
          System.Console.WriteLine("|  _ _  |");
          System.Console.WriteLine( "| ( v ) |");
          System.Console.WriteLine( "|  \\ /  |");
          System.Console.WriteLine( "|   .   |");
          System.Console.WriteLine($"|    {val2}|");
          System.Console.WriteLine("|_______|");
      }
  }
  public void PrintWin()
  {
    System.Console.WriteLine("  ___    ___ ________  ___  ___          ___       __   ________  ________   ___  ___  ___       ");
    System.Console.WriteLine(" |\\  \\  /  /|\\   __  \\|\\  \\|\\  \\        |\\  \\     |\\  \\|\\   __  \\|\\   ___  \\|\\  \\|\\  \\|\\  \\   ");
    System.Console.WriteLine(" \\ \\  \\/  / | \\  \\|\\  \\ \\  \\\\\\  \\       \\ \\  \\    \\ \\  \\ \\  \\|\\  \\ \\  \\\\ \\  \\ \\  \\ \\  \\ \\  \\  ");
    System.Console.WriteLine("  \\ \\    / / \\ \\  \\\\\\  \\ \\  \\\\\\  \\       \\ \\  \\  __\\ \\  \\ \\  \\\\\\  \\ \\  \\\\ \\  \\ \\  \\ \\  \\ \\  \\   ");
    System.Console.WriteLine("   \\/  /  /   \\ \\  \\\\\\  \\ \\  \\\\\\  \\       \\ \\  \\|\\__\\_\\  \\ \\  \\\\\\  \\ \\  \\\\ \\  \\ \\__\\ \\__\\ \\__\\   ");
    System.Console.WriteLine(" __/  / /      \\ \\_______\\ \\_______\\       \\ \\____________\\ \\_______\\ \\__\\\\ \\__\\|__|\\|__|\\|__|   ");
    System.Console.WriteLine("|\\___/ /        \\|_______|\\|_______|        \\|____________|\\|_______|\\|__| \\|__|   ___  ___  ___ ");
    System.Console.WriteLine("\\|___|/                                                                           |\\__\\|\\__\\|\\__\\");
    System.Console.WriteLine("                                                                                  \\|__|\\|__|\\|__|");

  }
}
