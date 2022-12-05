using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElementType = System.Int64;

namespace SimulaServidor {

    class Cola {
		private Node first;
		private Node last;

		private class Node {
			public ElementType data;
			public Node next, prev;

			public Node(ElementType i) { // Node constructor
				data = i;
				next = null;
				prev = null;
			}

		};

		public Cola() {
			first = null;
			last = null;
		}

		//Add to the back of the queue
		public void Enqueue() {
			Node nPtr = new Node(10);
			Node predPtr = first;

			if (first == null) { //Insert if queue is empty
				nPtr.next = first;
				nPtr.prev = first;
				first = nPtr;
			} else {
				while (predPtr.next != null) {
					predPtr = predPtr.next;
				}
				nPtr.prev = predPtr;
				nPtr.next = predPtr.next;
				predPtr.next = nPtr;
			}

			last = nPtr; //Set last to new pointer}
		}
		//Remove from the front of the queue
		public void Dequeue() {
			Node dPtr = first;
			first = first?.next;
		}

		//Returns the front of the queue
		public ElementType Front() {
			Node ptr = first;
			return ptr.data;
		}

		//Return size of the queue
		public int GetSize() {
			int mySize = 0;
			Node ptr = first;
			while (ptr != null) {
				ptr = ptr.next;
				mySize++;
			}
			return mySize;
		}
	}
}
