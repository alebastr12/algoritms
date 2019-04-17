#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <locale.h>
#include <malloc.h>
#include <string.h>

typedef int T;
typedef struct Node {
	T data;
	struct Node *left;
	struct Node *right;
	struct Node *parent;
} Node;

//Хэш функция
int hash(char * string) {
	if (string == NULL) return 0;
	int i = 0;
	int res = 0;
	int strlength = strlen(string);
	while (i < strlength) {
		res = (res * 1664525) + (unsigned char)string[i] + 1013904223; 
		i++;
	}
	return res;
}

// Распечатка двоичного дерева в виде скобочной записи
void printTree(Node *root) {
	if (root)
	{
		printf("%d", root->data);
		if (root->left || root->right)
		{
			printf("(");

			if (root->left)
				printTree(root->left);
			else
				printf("NULL");
			printf(",");

			if (root->right)
				printTree(root->right);
			else
				printf("NULL");
			printf(")");
		}
	}
}

// Создание нового узла
Node* getFreeNode(T value, Node *parent) {
	Node* tmp = (Node*)malloc(sizeof(Node));
	tmp->left = tmp->right = NULL;
	tmp->data = value;
	tmp->parent = parent;
	return tmp;
}
//Поиск элемента
Node * findElement(Node **head, int value) {
	if (*head == NULL) {
		return NULL;
	}
	Node *tmp = NULL;
	Node *res = NULL;
	tmp = *head;
	while (tmp) {
		if (value == tmp->data) {
			res = tmp;
			break;
		}
		else if (value > tmp->data) 
				tmp = tmp->right;
		else if (value < tmp->data) 
				tmp = tmp->left;
	}
	return res;
}

// Вставка узла
void insert(Node **head, int value) {
	Node *tmp = NULL;
	if (*head == NULL)
	{
		*head = getFreeNode(value, NULL);
		return;
	}

	tmp = *head;
	while (tmp)
	{
		if (value > tmp->data)
		{
			if (tmp->right)
			{
				tmp = tmp->right;
				continue;
			}
			else
			{
				tmp->right = getFreeNode(value, tmp);
				return;
			}
		}
		else if (value < tmp->data)
		{
			if (tmp->left)
			{
				tmp = tmp->left;
				continue;
			}
			else
			{
				tmp->left = getFreeNode(value, tmp);
				return;
			}
		}
		else
		{
			exit(2);                     // Дерево построено неправильно
		}
	}
}

void preOrderTravers(Node* root) {
	if (root) {
		printf("%d ", root->data);
		preOrderTravers(root->left);
		preOrderTravers(root->right);
	}
}

void inOrderTravers(Node* root) {
	if (root) {
		inOrderTravers(root->left);
		printf("%d ", root->data);
		inOrderTravers(root->right);
	}
}

void postOrderTravers(Node* root) {
	if (root) {
		postOrderTravers(root->left);
		postOrderTravers(root->right);
		printf("%d ", root->data);
	}
}



int main() {
	setlocale(LC_ALL, "Rus");

#pragma region Хэш функция
	char str[128];
	printf("Введите строку:");
	scanf("%s", &str);
	printf("\nХэш строки: %d",hash(str));
	printf("\n");
	system("pause");
#pragma endregion

#pragma region Двоичное дерево поиска
	Node *Tree = NULL;
	FILE* file = fopen("c:\\Users\\Алкесандр\\source\\repos\\algoritms\\lesson6\\Debug\\data.txt", "r");
	if (file == NULL)
	{
		puts("Can't open file!");
		exit(1);
	}
	int count;
	fscanf(file, "%d", &count);          // Считываем количество записей
	int i;
	for (i = 0; i < count; i++)
	{
		int value;
		fscanf(file, "%d", &value);
		insert(&Tree, value);
	}
	fclose(file);
	printTree(Tree);
	printf("\nPreOrderTravers:");
	preOrderTravers(Tree);
	printf("\nInOrderTravers:");
	inOrderTravers(Tree);
	printf("\nPostOrderTravers:");
	postOrderTravers(Tree);
	printf("\nНайти элемент:");

	int val;
	scanf("%d", &val);
	Node* elem = findElement(&Tree, val);
	if (elem == NULL)
		printf("\nЭлемент не найден");
	else
		printf("\nНайден элемент %d", elem->data);

	printf("\n");
	system("pause");
#pragma endregion

	return 0;
}