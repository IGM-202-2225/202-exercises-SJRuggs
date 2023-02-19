#pragma once
using namespace std;

class Foo
{
	int* m_pContentList = nullptr;
	int m_iListSize = 0;
public:
	Foo(int a_iSize = 10)
	{
		m_iListSize = a_iSize;
		m_pContentList = new int[m_iListSize];
		for (int i = 0; i < m_iListSize; i++)
		{
			m_pContentList[i] = i;
		}
	}
	Foo(Foo& a_oFooRef)
	{
		m_iListSize = a_oFooRef.m_iListSize;
		m_pContentList = new int[m_iListSize];
		for (int i = 0; i < m_iListSize; i++)
		{
			m_pContentList[i] = a_oFooRef.m_pContentList[i];
		}
	}
	void Print(void)
	{
		for (int i = 0; i < m_iListSize; i++)
		{
			if (i > 0)
			{
				std::cout << ", ";
			}
			std::cout << m_pContentList[i];
		}
		std::cout << endl;
	}
	~Foo()
	{
		if (m_pContentList != nullptr)
		{
			delete[] m_pContentList;
			m_pContentList = nullptr;
		}
	}
};