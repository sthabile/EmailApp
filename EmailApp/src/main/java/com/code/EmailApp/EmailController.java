package com.code.EmailApp;

//CONTROLLER CLASS
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.servlet.ModelAndView;



/*
    Ths controller handles the the form submission
*/ 
@Controller
public class EmailController{
    //More like the initial page
    @RequestMapping(value = "/start", method = RequestMethod.GET)
    public ModelAndView index(Model model)
    {
        ModelAndView mv = new ModelAndView("start");
        return mv;
    }

    //Processing of the input data
    @RequestMapping(value = "/createEmail" , method = RequestMethod.GET)
    public ModelAndView createEmail(@ModelAttribute Email email, @RequestParam String firstName, @RequestParam  String lastName ) //object populated from the html page
    {
        ModelAndView mv = new ModelAndView("start");
        // String n = "STHA";
        // String l ="LUSH";
        email.setEmail(firstName,lastName);
        mv.addObject("Email", email);
        return mv;
    }
}