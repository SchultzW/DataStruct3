using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class TextClass
    {
       public class Link
        {
            public char Value { get; set; }
            public Link Next { get; set; }
            public Link Previous { get; set; }

        }
        
        public class MyLinkedList
        {
            public Link Head { get; set; }
            public Link Tail { get; set; }
            public Link Iter = null;//pointer to a link
            public int Count = 0;

            public void InsertHead(char val)
            {
                Link temp = new Link();
                temp.Value = val;
                temp.Next = Head;
                temp.Previous = null;
                Head = temp;
                if (Head == null)
                {
                    Head = Tail = temp;

                }
                Head = Head.Previous = temp;
                Count++;
            }
            public char DeleteHead()
            {
                Count--;
                if (Head == null)
                {
                    throw new InvalidOperationException("Head returned null");
                }
                char val = Head.Value;
                Head = Head.Next;
                if (Head == null)
                {
                    Tail = null;
                }
                else
                    Head.Previous = null;
                return val;
               
            }
            public void InsertTail(char val)
            {
                Count++;
                Link temp = new Link()
                {
                    Value = val,
                    Next = null,
                    Previous = Tail
                };
                if (Tail == null)
                {
                    Head = Tail = temp;
                }
                else
                    Tail = Tail.Next = temp;
               

            }
            public char DeleteTail()
            {
                
                Count--;
                if (Tail == null)
                {
                    throw new InvalidOperationException("Tail returned null");
                }
                char val = Tail.Value;
                Link temp = Tail;
                Tail = Tail.Previous;
                if(Tail==null)
                {
                    Head = null;
                }
                return val;
            }
            public bool isEmpty()
            {
                if (Count == 0)
                    return true;
                else
                    return false;
                    
                
            }
            //searches for char and sets itr to it. returns true if found
            public bool FindKey(char key)
            {
                if (Head == null)
                    return false;
                Link ptr = Head;

                for (int i = 0; i < Count; i++)
                {
              
                    if (ptr.Value == key)
                    {
                        Iter = ptr;
                        return true;
                    }
                    else
                        ptr = ptr.Next;
                }
                return false;
            }
            //inserts into list previous to link pointed to by iter
            //return true on success
            //if iter==null return false
            public bool InsertKey(char key)
            {
                try
                {

                    if (Iter == null)
                        return false;
                    Link prev = Iter.Previous;
                    Link l = new Link
                    {
                        Value = key,
                        Next = Iter,
                        Previous = prev

                    };
                   
                    Iter.Previous = l;
                    if(prev!=null)
                        prev.Next = l;



                    Count++;
                    return true;
                }
                catch
                {
                    throw new ArgumentOutOfRangeException("something has gone horribly wrong");
                }
            }
            /// <summary>
            /// if iter==null return false
            /// else
            /// delete link
            /// set inter to null
            /// return true
            /// </summary>
          
            public bool DeleteIter()
            {
                if (Iter == null)
                    return false;
                Link prev = Iter.Previous;
                Link next = Iter.Next;
                next.Previous = prev;
                prev.Next = next;
                
                Iter = null;
                Count--;
                return true;
            }
            /// <summary>
            /// Delete first link with value
            /// reutrn true
            /// else false
            /// 
            /// if link is iter, set iter to null
            /// </summary>

            public bool DeleteKey(char key)
            {

                try
                {
                    if (Head == null)
                        return false;
                    Link ptr = Head;
                    Link prev = new Link();
                    for (int i = 0; i < Count; i++)
                    {
                        if (ptr.Value == key)
                        {
                           
                            break;
                        }
                        else
                            ptr = ptr.Next;
                    }
                 
                    Link next = ptr.Next;
                    prev.Next = next;
                    next.Previous = prev;
                    if (ptr.Equals(Iter))
                    {
                        Iter = null;
                    }
                    Count--;
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            public string DisplayList()
            {
                string message = "";
                if (Head == null)
                    return message;
                Link ptr = Head;

                for (int i = 0; i < Count; i++)
                {
                    if (ptr == null)
                        break;
                    message += " " + ptr.Value;
                    ptr = ptr.Next;
                }
                return message;
            }
            public static void AppendList(MyLinkedList aList,ref MyLinkedList bList)
            {
              
                Link previous = new Link();
                Link next = new Link();

                //add from
                Link ptr = bList.Head;
                //add to
                Link last = aList.Tail;
             
                
                for (int i = 0; i < bList.Count; i++)
                {


                    aList.InsertTail(ptr.Value);
              

                    ptr = ptr.Next;
                    if (last != null)
                        last = last.Next;

                    //last.Next = ptr;
                    ////ptr.Next = last;

                    //ptr = ptr.Next;
                        
              
                }
            }

        }

    }
}
