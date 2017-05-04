create table questions
(
	question_number	int				identity(1,1),
	question		varchar(200),
	choice_1		varchar(200),
	choice_2		varchar(200),
	choice_3		varchar(200),
	choice_4		varchar(200),
	correct_answer	varchar(200),

	constraint question_number Primary Key(question_number)

	);

	insert into questions values( 'In what year was Mozart born?', '1756', '1832', '1543', '1243', 'a');
	insert into questions values( 'What color is the sky?', 'purple', 'green', 'blue', 'red', 'c');
	insert into questions values( 'How much wood would a woodchuck chuck if a woodchuck could chuck wood?', '3 metric tons', 'none', 'all the wood he could chuck', '5 lbs.', 'c');
	insert into questions values( 'Why did the chicken cross the road?', 'Because he felt like it', 'To get to the other side', 'He was feeling adventurous', 'To get away from the farmer', 'b');
	insert into questions values( 'In what year was Schubert born?', '1756', '1787', '1543', '1797', 'd');
	