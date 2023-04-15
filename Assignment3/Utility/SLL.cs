using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Runtime.Serialization;
using System.Reflection;

namespace Assignment3.Utility
{
    [DataContract]
    public class SLL : ILinkedListADT
    {
        [DataMember]
        public Node Head { get; set; }
        private int _count = 0;

        [OnDeserialized]
        private void onDeserialization(StreamingContext context)
        {
            _count = 0;
            Node current =this.Head;
            while (current != null)
            {
                _count++;
                current = current.Next;
            }
           
          
        }

        public SLL()
        {
            Head = null;
            _count = 0;
        }
        public void Add(User value, int index)
        {
            //if index doesn't exist
            Node newNode = new Node();
            newNode.Value = value;

            Node Current = this.Head;

            for (int i = 0; i < index - 1; i++) 
            {
               Current = Current.Next;
            }
            newNode.Next = Current.Next;
            Current.Next = newNode;
            _count++;

        }

        public void AddFirst(User value)
        {
            Node newNode = new Node();
            newNode.Value = value;
            Node head = this.Head;
            newNode.Next = head;
            this.Head = newNode;
            this._count++;
        }

        public void AddLast(User value)
        {
            Node newNode = new Node();

            newNode.Value = value;

            if (Head == null)
            {
                this.Head = newNode;
            }

            else
            {
                Node current = this.Head;

                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newNode;
            }
            _count++;
        }

        public void Clear()
        {
            this.Head = null;
            this._count = 0;
        }

        public bool Contains(User value)
        {
            Node current = this.Head;
            while (current != null)
            {
                if (current.Value == value)
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public int Count()
        {
            return _count;
        }

        public User GetValue(int index)
        {
            Node current = this.Head;
            if (index <= -1)
            {
                return null;
            }
            else
            {
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                return current.Value;
            }
            
        }

        public int IndexOf(User value)
        {
            Node current = this.Head;
            int i = 0;
            while (current != null)
            {
                if (current.Value.Id == value.Id &&
                    current.Value.Name == value.Name &&
                    current.Value.Email == value.Email &&
                    current.Value.Password == value.Password)
                    
                {
                    return i;
                }
                current= current.Next;
                i++;
            }
            return -1;

        }

        public bool IsEmpty()
        {
            if (this.Head == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       

        public void RemoveFirst()
        {

            this.Head = this.Head.Next;
            _count--;
        }

        public void RemoveLast()
        {
            Node current = this.Head;
            while (current.Next.Next != null)
            {
                current = current.Next;
            }
            current.Next = null;
            
            _count--;
        }
        public void Remove(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                this.Head = this.Head.Next;
                _count--;
            }

            else
            {
                Node current = this.Head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                current.Next = current.Next.Next;
                _count--;
            }
        }


        public void Replace(User value, int index)
        {
            Node current = this.Head;
            for (int i = 0; i < index; i++) 
            {
                current = current.Next;
            }
            current.Value = value;
        }

        public List<string> AddToArray()
        {
            List<string> unlinked = new List<string>();
            Node current = this.Head;
            while (current != null) 
            {
                unlinked.Add(current.Value.ToString());
                current = current.Next;
            }
            return unlinked;
        }
    }
}
