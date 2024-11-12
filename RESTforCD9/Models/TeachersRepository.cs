namespace RESTforCD9.Models
{
    public class TeachersRepository
    {
        private List<Teacher> teachers = new List<Teacher>();
        private int nextId = 1;

        public TeachersRepository()
        {
            teachers.Add(new Teacher { Id = nextId++, Name = "John", Salary = 50000 });
            teachers.Add(new Teacher { Id = nextId++, Name = "Jane", Salary = 60000 });
            teachers.Add(new Teacher { Id = nextId++, Name = "Jim", Salary = 70000 });
        }

        public IEnumerable<Teacher> GetTeachers()
        {
            return new List<Teacher>(teachers);
        }

        public Teacher? GetTeacher(int id)
        {
            return teachers.FirstOrDefault(t => t.Id == id);
        }

        public Teacher AddTeacher(Teacher teacher)
        {
            teacher.ValidateSalary();
            teacher.Id = nextId++;
            teachers.Add(teacher);
            return teacher;
        }
    }
}
