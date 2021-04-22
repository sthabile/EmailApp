package com.code.EmailApp;
//MODEL CLASS
public class Email {
   private String firstName;
   private String lastName;
   private String companyName;
   private String email;

   public Email(){

   }

    public Email(String firstName, String lastName) {
        this.firstName = firstName;
        this.lastName = lastName;
    }


    public String getDepartment() {
        return companyName;
    }

    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    public String getCompanyName() {
        return companyName;
    }

    public void setCompanyName(String companyName) {
        this.companyName = companyName;
    }

    public void setDepartment(String department) {
        this.companyName = department;
    }


    public String getEmail() {
        return email;
    }


    public void setEmail(String firstName, String lastName) {
        CreateEmail(firstName,lastName);
    }

    private void CreateEmail(String firstName, String lastName){
        String emailString = firstName + "."+ lastName + "@mymail" + ".com";
        this.email = emailString;
    }


    @Override
    public String toString() {
        return "Email [companyName=" + companyName + ", email=" + email + ", fisrtName=" + firstName + ", lastName="
                + lastName + "]";
    }

   
}
