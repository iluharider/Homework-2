using System;

class Node
{
    public int key;
    public int value;

    public Node(int key, int value)
    {
        this.key = key;
        this.value = value;
    }
    
}

class HashMap
{
    private Node[] table;
    private int capacity;
    private int size;

    static Node dummy = new Node(-1, -1); //special item for marking space with deleted element

    public HashMap(int capacity)
    {
        this.capacity = capacity;
        table = new Node[capacity];
        size = 0;
    }

    public int HashFunction(int key) { return key % capacity; }

    public void Insert(int key, int value)
    {
        int hashIndex = HashFunction(key);
        Node newNode = new Node(key, value);

        if (table[hashIndex] != null && table[hashIndex].key != -1 && table[hashIndex].key != key) //find new place, if this hashIndex's cell isn't empty
        {
            hashIndex++;
            HashFunction(hashIndex);
        }

        if (table[hashIndex] == null || table[hashIndex].key == -1) //if it is truly new Node, not just updating the value, increase size
            size++;

        table[hashIndex] = newNode; 
    }

    public int? Delete(int key)
    {
        int hashIndex = HashFunction(key);

        while (table[hashIndex] != null)
        {
            while (table[hashIndex] != null)
            {
                if (table[hashIndex].key == key)
                {
                    table[hashIndex] = dummy;
                    size--;
                }
                hashIndex++;
                HashFunction(hashIndex);
            }
        }

        return null;
    }
    
    public int Find(int key)
    {
        int hashIndex = HashFunction(key);
        int counter = 0;

        while (table[hashIndex] != null)
        {
            if (counter > capacity)
                break;

            if (table[hashIndex].key == key)
            {
                return table[hashIndex].value;
            }

            hashIndex++;
            HashFunction(hashIndex);
            counter++;
        }
        return -1;
    }
}

class Program
{
    static void Main(string[] args)
    {
        HashMap h = new HashMap(5);
        h.Insert(1, 5);
        h.Insert(2, 2);

        if (h.Find(1) != -1)
            Console.WriteLine("first item was successfully inserted and then found");
        h.Delete(2);
        if (h.Find(2) == -1)
            Console.WriteLine("second item was successfully deleted");
        h.Insert(6, 9);
        if (h.Find(6) != -1)
            Console.WriteLine("element was added although it has the same hash_code as the fst elem");
    }
}
