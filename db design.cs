
Enum Track {
  hire
  learn
}

Enum WhoCanInitiate {
  bot
  user
  both
}
Enum JobTitle {
  backend
  frontend
  fullStack
  Hr
}
// Creating tables
Table Employee_data{
  id bigint[pk]
  employee_name varchar(50)
  employee_email varchar(50)
  created_at timestamp
  is_active bit
}
Table Company_Users{
  id bigint[pk]
  company_id bigint[increment]
  username varchar(30)
  password varchar(100)
  is_superuser bit
  created_at timestamp
  is_active bit
  
}

Table tests as I {
  id bigint [pk, increment] // auto-increment
  is_creator_comapany bit
  institute_name varchar(100)
  track Track
  report_type varchar(20)
  test_code varchar(100)
  access_code varchar(20)
  interview_mode varchar(20)
  who_can_initiate WhoCanInitiate
  expiry_date datetime
  timer timer
  phone_number varchar(100)
  Generate_certificate bit
  Generate_certificate_text varchar(100)
  collect_candidate_mail bit
  voice_match bit
  collect_resume bit
  job_code bigint
  job_title JobTitle
  job_describtion varchar(255)
  total_question int
  created_at timestamp [default: `now()`]
  createdby_id bigint
  updated_at timestamp
  updatedby_id timestamp
  is_active bit
  notification_id bigint
  company_id bigint
}

Table companies {
  id int [pk, increment]
  name varchar
  phone_number varchar(12)
  plan_id varchar 
  created_at timestamp [default: `now()`]
  createdby_id bigint 
  updated_at timestamp
  updatedby_id timestamp
  is_active bit
 }

// > many-to-one; < one-to-many; - one-to-one
Ref: I.company_id > companies.id  
Ref: companies.plan_id - plan.id

//----------------------------------------------//

Table Responces{
  id bigint [pk, increment]
  responce varchar(100)
  question_id bigint
  candidate_id bigint
  interaction_id bigint
  created_at timestamp [default: `now()`]
  createdby_id bigint
  updated_at timestamp
  updatedby_id timestamp
  is_active bit
}

Ref: questions.id - Responces.question_id 
Ref: Responces.candidate_id - Candidates.id
Ref: Responces.interaction_id - Interactions.id

Table Candidates{
  id bigint [pk, increment]
  name varchar (20)
  phone_number varchar(12)
  email varchar(20)
  created_at timestamp [default: `now()`]
  createdby_id bigint
  updated_at timestamp
  updatedby_id timestamp
  is_active bit
}

Table Interactions{
  id bigint [pk, increment]
  candidate_id bigint
  test_id bigint
  candidate_feedback varchar
  report_send_to_user bit
  url varchar(100)
  channel_1 varchar(20)
  channel_2 varchar(20)
  created_at timestamp [default: `now()`]
  createdby_id bigint
  updated_at timestamp
  updatedby_id timestamp
  score_id bigint
  individual_report_id bigint
  is_active bit
}

Ref: Interactions.test_id > tests.id
Ref: Candidates.id - Interactions.candidate_id
Ref: individual_reports.id - Interactions.individual_report_id

Table Scores{
  id bigint [pk, increment]
  mcq_percentage bigint
  sales_quotient bigint
  manager_quotient bigint
  leadership_quotient bigint
  learner_quotient bigint
  sales_quotient_percentile bigint
  people_qutient_percentile bigint
  manager_quotient_percentile bigint
  leadership_quotient_percentile bigint
  learner_quotient_percentile bigint
  people_qutient bigint
  resume_score bigint
  pace bigint
  power_word_density bigint
  word_cloud bigint
  volume bigint
  pitch bigint
  estimated_gesture_score bigint
  aggregate_content_score bigint
  raw_interaction_score bigint
  interaction_percentile bigint 
  interaction_score bigint
  
}

Ref: Scores.id - Interactions.score_id
Ref: Scores.id - Score_per_Question.score_id

Table Score_per_Question{
  id bigint [pk, increment]
  score_id bigint
  question_id bigint
  mcq_value int
  likeability int
  charm int
  transcript int
  confidence int
  fluency int
  content_score int 
  per_question_content_score int
  silence_number int
  silence_length int
  filler_words_score int
  sentiment_score int
}

//----------------------------------------------//

Enum PlanName {
  standard
  premium
  enterprise
}

Enum interaction {
  one
  ten
  unlimited
}

Enum interactionType {
  audio
  audio_video
  any
}

Enum Responce {
  unlimited
}

Enum Time {
  one_quarter
  unlimited
}

Enum AnswerFormat {
  one_quarter
  unlimited
}
// Indexes: You can define a single or multi-column index 
Table questions {
  id int [pk, increment]
  question varchar(2000)
  answer_format AnswerFormat
  ideal_answer varchar(20)
  test_id bigint
  rated bit
  content_rated bit
  created_at datetime [default: `now()`]
  createdby_id bigint
  updated_at timestamp
  should_score bit
  updatedby_id timestamp
  is_active bit

  Indexes {
    (test_id)
    id [unique]
  }
}
  
Ref: questions.test_id > tests.id 
  

Table plan {
  id int [pk, increment]
  name PlanName
  interaction_allowed interaction
  interaction_type_allowed interactionType
  responses Responce
  time Time
  created_at datetime [default: `now()`]
  createdby_id bigint
  updated_at timestamp
  updatedby_id timestamp
  is_active bit
}

Table notifications{
  id bigint [pk,increment]
  Interaction_Title varchar(20)
  interaction_welcome varchar(500)
  interaction_instruction varchar(500)
  interaction_completion_message varchar(500)
  bot_error_message varchar(500)
  created_at datetime [default: `now()`]
  createdby_id bigint
  updated_at timestamp
  updatedby_id timestamp
  is_active bit
}

Ref: notifications.id - tests.notification_id


Table individual_reports{
  id bigint [pk,increment]
  track Track
  initial_box varchar
  letter_text varchar
  rating_variable varchar
  pace_text varchar
  power_word_text varchar
  volume_and_pitch varchar
  word_cloud_text varchar
  sentiment_analysis varchar
  gesture_text varchar
  content_rating_text varchar
}

Table leaderboard_report{
  id bigint [pk,increment]
  track Track
  initial_box varchar
  letter_text varchar
  rating_variable varchar
}
