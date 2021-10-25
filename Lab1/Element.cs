namespace Lab1
{
  internal class Element<T>
  {
    private T data;

    public Element(T data) => this.data = data;

    public Element()
    {
    }

    public T Data
    {
      get => this.data;
      set => this.data = value;
    }
  }
}
