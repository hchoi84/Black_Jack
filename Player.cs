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
      Console.WriteLine($"{c.getStringVal} of {c.getSuite}");
  }

  public string ShowSecondCard()
  {
    return $"{hand[1].getStringVal} of {hand[1].getSuite}";
  }
}