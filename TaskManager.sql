use master
if DB_ID('TaskManager') is not null drop database TaskManager;
create database TaskManager;
go
use TaskManager;

-- Создание таблиц

create table Account
(
	Id	  int identity(1, 1) primary key,
	Login nvarchar(20) not null unique,
	pass  nvarchar(30) not null
);

create table Priority
(
	Title nvarchar(20) primary key default('Без приоритета'),
	Color nvarchar(20) not null unique default('White')
);

create table Project
(
	Id int identity(1, 1) primary key,
	Title nvarchar(20) not null unique,
	-- Режим видимости задач проекта (включён ли скрытый список).
	-- 0 - задачи проекта отображаются в других списках,
	-- 1 - не отображаются (можно посмотреть только в этом проекте).
	InvisibleMode bit not null
);

create table Task
(
	Id			  int identity(1, 1) primary key,
	Title		  nvarchar(50) not null,
	Description	  nvarchar(100) not null,
	Date		  date null,
	-- Приоритет задачи
	PriorityTitle nvarchar(20) not null unique
							   references Priority(Title)
							   on delete cascade
							   on update no action,
	-- Проект, в котором находится задача
	ProjectId     int not null unique
					  references Project(Id)
					  on delete cascade
					  on update no action,
	-- Пользователь, который владеет задачей
	UserId		  int not null unique
					  references Account(Id)
					  on delete cascade
					  on update no action
);




--create table Tag
--(
--	Title nvarchar(10) primary key,
--	Color nvarchar(20) not null
--);

--create table TaskTags
--(
--	Number	 int,
--	TaskId	 int references Task(Id)
--			     on delete cascade
--			     on update no action,
--	TagTitle nvarchar(10) references Tag(Title)
--						  on delete cascade
--						  on update no action,
--	primary key(Number, TaskId)
--);