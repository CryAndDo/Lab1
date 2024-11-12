using System;
using System.Collections.Generic;
using System.Linq;

// Абстракция: класс множества
public abstract class Set
{
   
    protected IDataStructure dataStructure;

    public Set(IDataStructure dataStructure)
    {
        this.dataStructure = dataStructure;
    }

    public abstract void Add(int element);
    public abstract void Remove(int element);
    public abstract bool Contains(int element);
    public abstract Set Union(Set otherSet);
    public abstract Set Intersection(Set otherSet);

    public IEnumerable<int> GetElements()
    {
        return dataStructure.GetElements();
    }
}

// Абстрактная реализация: интерфейс для структуры данных
public interface IDataStructure
{
    void AddElement(int element);
    void RemoveElement(int element);
    bool ContainsElement(int element);
    IEnumerable<int> GetElements();
}

// Конкретная реализация: Множество с использованием массива
public class ArrayDataStructure : IDataStructure
{
    private List<int> elements = new List<int>();

    public void AddElement(int element)
    {
        if (!elements.Contains(element))
        {
            elements.Add(element);
        }
    }

    public void RemoveElement(int element)
    {
        elements.Remove(element);
    }

    public bool ContainsElement(int element)
    {
        return elements.Contains(element);
    }

    public IEnumerable<int> GetElements()
    {
        return elements;
    }
}

// Конкретная реализация: Множество с использованием хэш-таблицы
public class HashSetDataStructure : IDataStructure
{
    private HashSet<int> elements = new HashSet<int>();

    public void AddElement(int element)
    {
        elements.Add(element);
    }

    public void RemoveElement(int element)
    {
        elements.Remove(element);
    }

    public bool ContainsElement(int element)
    {
        return elements.Contains(element);
    }

    public IEnumerable<int> GetElements()
    {
        return elements;
    }
}

// Конкретная реализация множества с использованием массива
public class ArraySet : Set
{
    public ArraySet(IDataStructure dataStructure) : base(dataStructure) { }

    public override void Add(int element)
    {
        dataStructure.AddElement(element);
    }

    public override void Remove(int element)
    {
        dataStructure.RemoveElement(element);
    }

    public override bool Contains(int element)
    {
        return dataStructure.ContainsElement(element);
    }

    public override Set Union(Set otherSet)
    {
        var resultSet = new ArraySet(new ArrayDataStructure());

       
        foreach (var item in this.GetElements()) 
        {
            resultSet.Add(item);
        }
        foreach (var item in otherSet.GetElements())  
        {
            resultSet.Add(item);
        }

        return resultSet;
    }

    public override Set Intersection(Set otherSet)
    {
        var resultSet = new ArraySet(new ArrayDataStructure());

        
        foreach (var item in this.GetElements())
        {
            if (otherSet.Contains(item))
            {
                resultSet.Add(item);
            }
        }

        return resultSet;
    }
}

// Конкретная реализация множества с использованием хэш-таблицы
public class HashSetSet : Set
{
    public HashSetSet(IDataStructure dataStructure) : base(dataStructure) { }

    public override void Add(int element)
    {
        dataStructure.AddElement(element);
    }

    public override void Remove(int element)
    {
        dataStructure.RemoveElement(element);
    }

    public override bool Contains(int element)
    {
        return dataStructure.ContainsElement(element);
    }

    public override Set Union(Set otherSet)
    {
        var resultSet = new HashSetSet(new HashSetDataStructure());

       
        foreach (var item in this.GetElements()) 
        {
            resultSet.Add(item);
        }
        foreach (var item in otherSet.GetElements())  
        {
            resultSet.Add(item);
        }

        return resultSet;
    }


    public override Set Intersection(Set otherSet)
    {
        var resultSet = new HashSetSet(new HashSetDataStructure());

        
        foreach (var item in this.GetElements())
        {
            if (otherSet.Contains(item))
            {
                resultSet.Add(item);
            }
        }

        return resultSet;
    }
}



class Program
{
    static void Main(string[] args)
    {
        Set smallSet = new ArraySet(new ArrayDataStructure());
        smallSet.Add(1);
        smallSet.Add(2);
        smallSet.Add(3);

        Set largeSet = new HashSetSet(new HashSetDataStructure());
        largeSet.Add(1);
        largeSet.Add(2);
        largeSet.Add(3);
        largeSet.Add(4);
        largeSet.Add(5);

        // Объединение множеств
        Set unionSet = smallSet.Union(largeSet);
        Console.WriteLine("Union:");
        foreach (var item in unionSet.GetElements())  // Используем GetElements() для доступа
        {
            Console.WriteLine(item);
        }

        // Пересечение множеств
        Set intersectionSet = smallSet.Intersection(largeSet);
        Console.WriteLine("Intersection:");
        foreach (var item in intersectionSet.GetElements())  // Используем GetElements() для доступа
        {
            Console.WriteLine(item);
        }
    }
}

