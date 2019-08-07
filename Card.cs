class Card
{
  private string stringVal;
  private string suite;
  private int val;

  public string getStringVal{ get{return stringVal;} }
  public string getSuite{ get{return suite;} }
  public int getVal{ get{return val;} }

  public Card(string stringVal, string suite, int val){
    this.stringVal = stringVal;
    this.suite = suite;
    this.val = val;
  }
}