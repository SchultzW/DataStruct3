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
                
            }
            public char DeleteHead()
            {
               
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
                if (Head == null)
                    return true;
                else
                    return false;
                    
                
            }
            //searches for char and sets itr to it. returns true if found
            public bool FindKey(char key)
            {
                int i = 0;
                bool wrap = false;
                if (Iter == null)
                    Iter = Head;
                while(wrap==false||Iter.Previous!=null)
                {
                   
                    if (Iter.Value == key)
                        return true;


                    else if (Iter.Next == null && i == 0)
                    {
                        i++;
                        Iter = Head;
                    }
                    else if (Iter.Next == null && i == 1)
                    {
                        return false;
                    }
                    else
                        Iter = Iter.Next;
                }
 
                //Link ptr = Head;

                //for (int i = 0; i < Count; i++)
                //{
              
                //    if (ptr.Value == key)
                //    {
                //        Iter = ptr;
                //        return true;
                //    }
                //    else
                //        ptr = ptr.Next;
                //}
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
                bool wrap = false;
                int i = 0;
                
                
                if (Head == null)
                    return false;
                Link ptr = Head;
                Link prev = new Link();

                //while (wrap == false)
                //{
                //    if (ptr.Value == key)
                //    {
                //        wrap = true;
                //    }
                //    else if(wrap==false&&i==0)
                //    {

                //    }
                //    else
                //        ptr = ptr.Next;
                //}
                while(ptr.Next!=null)
                {
                    if (ptr.Value == key)
                    {
                        break;
                    }
                    else
                        ptr = ptr.Next;
                }
                if(ptr.Next==null)
                {
                    return false;
                }

                Link next = ptr.Next;
                prev.Next = next;
                next.Previous = prev;
                if (ptr.Equals(Iter))
                {
                    Iter = null;
                }
                    
                return true;
                

            }

            public string DisplayList()
            {
                string message = "";
                if (Head == null)
                    return message;
                Link ptr = Head;


                do
                {
                    message += " " + ptr.Value;
                    ptr = ptr.Next;
                }
                while (ptr != null);

                //while (ptr.Next!=null)
                //{
                //    message += " " + ptr.Value;
                //    ptr = ptr.Next;
                //}
                //for (int i = 0; i < Count; i++)
                //{
                //    if (ptr == null)
                //        break;
                //    message += " " + ptr.Value;
                //    ptr = ptr.Next;
                //}
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
             
                
                //while(ptr.Next!=null)
                //{
                //    aList.InsertTail(ptr.Value);
                //    ptr = ptr.Next;

                //}

                do
                {
                    aList.InsertTail(ptr.Value);
                    ptr = ptr.Next;

                }
                while (ptr != null);

                //for (int i = 0; i < bList.Count; i++)
                //{


                //    aList.InsertTail(ptr.Value);


                //    //ptr = ptr.Next;
                //    //if (last != null)
                //    //    last = last.Next;

                //    //last.Next = ptr;
                //    ////ptr.Next = last;

                //    //ptr = ptr.Next;


                //}
            }

        }

    }
}
